using MultiTenancyTask.Domain.Entities;
using MultiTenancyTask.Domain.Interface;
using MultiTenancyTask.Domain.Repositories;
using MultiTenancyTask.Infrastructure.Data;
using MultiTenancyTask.InfraStructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancyTask.InfraStructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context context;
        public IGenericRepository<Employee> Employees { get; private set; }
        public IGenericRepository<Department> Departments { get; private set; }
        public UnitOfWork(Context _context)
        {
            context = _context;
            Employees=new GenericRepository<Employee>(context);
            Departments=new GenericRepository<Department>(context);
        }
      

      

        public async Task complete()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
           context.Dispose();
        }
    }
}
