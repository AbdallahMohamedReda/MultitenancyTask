
using MultiTenancyTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenancyTask.Domain.CQRS.Queries.GetAllDepartment;
using MultiTenancyTask.Domain.CQRS.Queries.GetDepartmentById;
using MultiTenancyTask.Domain.DTO;
using MultiTenancyTask.Application.CQRS.Commands.InsertDepartment;

namespace MultiTenancyTask.Application.CQRS
{
    public class DepartmentServiceCQRS : IDepartmentServiceCQRS
    {
        private readonly IMediator mediator;

        public DepartmentServiceCQRS(IMediator _mediator)
        {
            mediator = _mediator;
        }
        public async Task<List<Department>> GetAll()
        {
            return await mediator.Send(new GetAllDepartmentsQuery());
        }

        public async Task<Department> GetById(int id)
        {
            return await mediator.Send(new GetDepartmentByIdQuery(id));
        }

        public async Task Insert(DepartmentDTO departmentDTO)
        {
            await mediator.Send(new InsertDepartmentCommand(departmentDTO));
        }
    }
}
