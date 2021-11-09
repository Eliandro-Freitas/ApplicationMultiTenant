using EFCore.Multitenant.Domain;
using EFCore.Multitenant.Domain.Provider;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Multitenant.Infra
{
    public class ApplicationContext : DbContext
    {
        private TenantData _tenant;
        public ApplicationContext(DbContextOptions<ApplicationContext> options, TenantData tenant) : base(options)
            => _tenant = tenant;

        public DbSet<Person>? Peoples { get; set; }
        public DbSet<Product>? Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Eliandro", TenantId = "Tenant-1" },
                new Person { Id = 2, Name = "Elias", TenantId = "Tenant-2" },
                new Person { Id = 3, Name = "Sadrak", TenantId = "Tenant-2" });

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Description = "Description 1", TenantId = "Tenant-1" },
                new Product { Id = 2, Description = "Description 2", TenantId = "Tenant-2" },
                new Product { Id = 3, Description = "Description 3", TenantId = "Tenant-2" });

            modelBuilder.Entity<Person>().HasQueryFilter(x => _tenant.TenantId.Equals(x.TenantId));
            modelBuilder.Entity<Product>().HasQueryFilter(x => _tenant.TenantId.Equals(x.TenantId));
        }
    }
}