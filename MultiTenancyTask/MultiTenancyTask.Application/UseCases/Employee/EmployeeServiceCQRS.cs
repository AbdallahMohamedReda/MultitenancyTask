
using MultiTenancyTask.Domain.DTO;
using MultiTenancyTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenancyTask.Domain.CQRS.Queries.GetAllEmployee;
using MultiTenancyTask.Domain.CQRS.Queries.GetEmployessByAge;
using MultiTenancyTask.Domain.CQRS.Queries.GetEmployessById;
using MultiTenancyTask.Application.CQRS.Queries.GetEmployessByAge;
using MultiTenancyTask.Application.CQRS.Commands.InsertEmployee;
namespace MultiTenancyTask.Application.CQRS
{
    public class EmployeeServiceCQRS:IEmployeeServiceCQRS
    {
        private readonly IMediator mediator;

        public EmployeeServiceCQRS(IMediator _mediator)
        {
            mediator = _mediator;
        }
        public async Task<List<Employee>> GetAll()
        {
            return await mediator.Send(new GetAllEmployeesQuery());
        }

        public async Task<List<Employee>> GetAllByAge(int age)
        {
            return await mediator.Send(new GetEmployeeByAgeQuery(age));
        }

        public async Task<Employee> GetById(int Id)
        {
            return await mediator.Send(new GetEmployeeByIdQuery(Id));   
        }

        public async Task Insert(EmployeeDTO employeeDTO)
        {
            await mediator.Send(new InsertEmployeeCommand(employeeDTO));
        }
    }
}
