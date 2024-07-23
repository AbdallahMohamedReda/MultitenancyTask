using MultiTenancyTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancyTask.Application.CQRS.Queries.GetEmployessByAge
{
    public record GetEmployeeByAgeQuery(int age) : IRequest<List<Employee>>;

}
