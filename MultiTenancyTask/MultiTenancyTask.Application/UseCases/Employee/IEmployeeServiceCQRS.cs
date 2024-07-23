using MultiTenancyTask.Domain.DTO;
using MultiTenancyTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancyTask.Application.CQRS
{
    public interface IEmployeeServiceCQRS
    {
        Task<List<Employee>> GetAll();
        Task<List<Employee>> GetAllByAge(int age);
        Task Insert(EmployeeDTO employeeDTO);
        Task<Employee> GetById(int age);
    }
}
