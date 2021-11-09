namespace EFCore.Multitenant.Domain;
public abstract class BaseEntity
{
    public int Id { get; set; }
    public string TenantId { get; set; }
}