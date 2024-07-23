using MultiTenancyTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancyTask.Domain.CQRS.Queries.GetAllDepartment
{
    public record GetAllDepartmentsQuery : IRequest<List<Department>>;

}
