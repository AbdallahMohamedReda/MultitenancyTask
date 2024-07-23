using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MultiTenancyTask.Domain.Entities;

namespace MultiTenancyTask.InfraStructure.interceptors
{
    public class SavingChangesInterceptors: SaveChangesInterceptor
    {
        private readonly string tenatId;
        public SavingChangesInterceptors(string _tenantId)
        {
            tenatId = _tenantId;
        }
        public override  async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            foreach (var entry in eventData.Context.ChangeTracker.Entries<TenantParrentClass>().Where(e => e.State == EntityState.Added))
            {
                entry.Entity.TenantId = tenatId;
            }
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }
     
    }
}
