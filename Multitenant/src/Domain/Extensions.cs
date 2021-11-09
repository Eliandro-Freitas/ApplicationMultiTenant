namespace EFCore.Multitenant.Domain;

public static class Extensions
{
    public static string? GetTenantId(this HttpContext httpContext)
    {
        var tenantId = httpContext.Request?.Path.Value?.Split('/', System.StringSplitOptions.RemoveEmptyEntries)[0];
        return tenantId;
    }
}