using EFCore.Multitenant.Domain.Middlewares;
using EFCore.Multitenant.Domain.Provider;
using EFCore.Multitenant.Infra;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<TenantData>();
builder.Services.AddDbContext<ApplicationContext>(x => x
    .UseSqlServer("Data Source=localhost;Initial Catalog=Estudos;User Id=sa;Password=@Elifreitas0;")
    .LogTo(Console.WriteLine)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors());

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<TenantMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();