using MultiTenancyTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancyTask.Domain.CQRS.Queries.GetEmployessById
{
    public record GetEmployeeByIdQuery(int id) : IRequest<Employee>;

}
