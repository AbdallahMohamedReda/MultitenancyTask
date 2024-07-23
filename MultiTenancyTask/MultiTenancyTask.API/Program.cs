
using MediatR;
using Microsoft.EntityFrameworkCore;
using MultiTenancyTask.Application.CQRS;
using MultiTenancyTask.Domain.Interface;
using MultiTenancyTask.Domain.Repositories;
using MultiTenancyTask.Domain.Settings;
using MultiTenancyTask.Domain.TenantServices;
using MultiTenancyTask.Infrastructure.Data;
using MultiTenancyTask.InfraStructure.Repositories;
using MultiTenancyTask.InfraStructure.UnitOfWork;

namespace MultiTenancyTask.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            // Add services to the container.
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.Configure<TenantSetting>(builder.Configuration.GetSection("TenantSetting"));
            builder.Services.AddScoped<ITenantServices, TenantServices>();
            //builder.Services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();

            builder.Services.AddScoped<IEmployeeServiceCQRS, EmployeeServiceCQRS>();
            builder.Services.AddScoped<IDepartmentServiceCQRS, DepartmentServiceCQRS>();
            builder.Services.AddMediatR(MultiTenancyTask.Application.AssemblyReference.Assembly);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

           // app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
