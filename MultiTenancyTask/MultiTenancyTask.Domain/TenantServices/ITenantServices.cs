using MultiTenancyTask.Domain.Settings;

namespace MultiTenancyTask.Domain.TenantServices
{
    public interface ITenantServices
    {
         Tenent? GetCurrentTenant();
    }
}
