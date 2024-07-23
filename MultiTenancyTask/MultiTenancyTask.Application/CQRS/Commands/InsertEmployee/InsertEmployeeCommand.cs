using MultiTenancyTask.Domain.DTO;
using MultiTenancyTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancyTask.Application.CQRS.Commands.InsertEmployee
{
    public record InsertEmployeeCommand(EmployeeDTO employeeDTO) : IRequest;

}
