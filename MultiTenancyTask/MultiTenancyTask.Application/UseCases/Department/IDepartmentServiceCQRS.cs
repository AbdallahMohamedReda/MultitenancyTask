using MultiTenancyTask.Domain.DTO;
using MultiTenancyTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancyTask.Application.CQRS
{
    public interface IDepartmentServiceCQRS
    {
        Task<List<Department>> GetAll();
        Task Insert(DepartmentDTO departmentDTO);
        Task<Department> GetById(int id);
    }
}
