using EFCore.Multitenant.Domain.Provider;

namespace EFCore.Multitenant.Domain.Middlewares
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public TenantMiddleware(RequestDelegate requestDelegate)
            => _requestDelegate = requestDelegate;

        public async Task InvokeAsync(HttpContext context)
        {
            var tenant = context.RequestServices.GetRequiredService<TenantData>();

            tenant.TenantId = context.GetTenantId();
            await _requestDelegate(context);
        }
    }
}