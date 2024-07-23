using MultiTenancyTask.Domain.Entities;
using MultiTenancyTask.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancyTask.Domain.Interface
{
    public  interface IUnitOfWork:IDisposable
    {
        IGenericRepository<Employee> Employees { get; }
        IGenericRepository<Department> Departments { get; }
        Task complete();
    }
}
