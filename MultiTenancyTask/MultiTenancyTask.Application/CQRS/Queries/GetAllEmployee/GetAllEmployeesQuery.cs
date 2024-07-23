using MultiTenancyTask.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MultiTenancyTask.Domain.CQRS.Queries.GetAllEmployee
{
    public record GetAllEmployeesQuery : IRequest<List<Employee>>;

}
