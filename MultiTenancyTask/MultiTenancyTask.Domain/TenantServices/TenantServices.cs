using Microsoft.Extensions.Options;
using MultiTenancyTask.Domain.Settings;

using Microsoft.AspNetCore.Http;

namespace MultiTenancyTask.Domain.TenantServices
{
    public class TenantServices : ITenantServices
    {
        private readonly TenantSetting _tenantSetting;
        private HttpContext _httpContext;
        private Tenent? _currentTenant;
        //binding list of tenant in appsetting config to _Tenantsetting
        public TenantServices(IHttpContextAccessor httpContextAccessor,IOptions<TenantSetting> tenantsetting)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _tenantSetting = tenantsetting.Value;
        }
        public Tenent GetCurrentTenant()
        {
            if (_httpContext is not null)
            {
                // get tenant from request header
                if(_httpContext.Request.Headers.TryGetValue("tenant",out var tenantid ))
                {
                    //check if tenent is found in config
                    _currentTenant=_tenantSetting.Tenants.FirstOrDefault(d=>d.Tid==tenantid);
                    if (_currentTenant == null)
                        throw new Exception("not valid Tenant");
                    return _currentTenant;
                }
                throw new Exception("no tenant found");
            }
            throw new Exception("no tenant found");
        }
    }
}
