using MultiTenancyTask.Domain.DTO;
using MultiTenancyTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenancyTask.Domain.Repositories;
using MultiTenancyTask.Domain.Interface;

namespace MultiTenancyTask.Application.CQRS.Commands.InsertEmployee
{
    public class InsertEmployeeHandler : IRequestHandler<InsertEmployeeCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public InsertEmployeeHandler(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public async Task<Unit> Handle(InsertEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (request.employeeDTO != null)
            {
                Employee emp = new Employee();
                emp.Name = request.employeeDTO.Name;
                emp.Salary = request.employeeDTO.Salary;
                emp.Address = request.employeeDTO.Address;
                emp.Age = request.employeeDTO.Age;
                emp.Dept_Id = request.employeeDTO.Dept_Id;
                await unitOfWork.Employees.add(emp);
                await unitOfWork.complete();
            }
            return new Unit();
        }
    }
}
