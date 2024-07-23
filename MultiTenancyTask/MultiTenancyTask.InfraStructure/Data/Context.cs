
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;
using MultiTenancyTask.Domain.TenantServices;
using MultiTenancyTask.InfraStructure.interceptors;
using MultiTenancyTask.Domain.Entities;

namespace MultiTenancyTask.Infrastructure.Data
{
    public class Context : DbContext
    {
        public string TenatId { get; set; }
        private readonly IConfiguration config;
        private readonly ITenantServices tenantServices;
        public Context()
        {

        }
        public Context(DbContextOptions contextOptions, ITenantServices _tenantServices, IConfiguration _config)
           : base(contextOptions)
        {
            tenantServices = _tenantServices;
            TenatId = tenantServices.GetCurrentTenant().Tid;
            config = _config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"))
                .AddInterceptors(new SavingChangesInterceptors(TenatId) );
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Expression<Func<TenantParrentClass, bool>> filterExpr = tenant=>tenant.TenantId==TenatId;
            foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes())
            {
                // check if current entity type is child of TenantParrentClass
                if (mutableEntityType.ClrType.IsAssignableTo(typeof(TenantParrentClass)))
                {
                    // modify expression to handle correct child type
                    var parameter = Expression.Parameter(mutableEntityType.ClrType);
                    var body = ReplacingExpressionVisitor.Replace(filterExpr.Parameters.First(), parameter, filterExpr.Body);
                    var lambdaExpression = Expression.Lambda(body, parameter);
                    modelBuilder.Entity(mutableEntityType.ClrType).HasQueryFilter(lambdaExpression);

                }
            }
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Department { get; set; }

    }
}
