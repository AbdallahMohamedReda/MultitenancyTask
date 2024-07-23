using MultiTenancyTask.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancyTask.Application.CQRS.Commands.InsertDepartment
{
    public record InsertDepartmentCommand(DepartmentDTO DepartmentDTO) : IRequest;

}
