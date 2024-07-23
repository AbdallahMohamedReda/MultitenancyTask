using MultiTenancyTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenancyTask.Domain.Repositories;
using MultiTenancyTask.Domain.Interface;

namespace MultiTenancyTask.Application.CQRS.Queries.GetEmployessByAge
{
    public class GetEmployeeListByAgeQueryHandler : IRequestHandler<GetEmployeeByAgeQuery, List<Employee>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetEmployeeListByAgeQueryHandler(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<List<Employee>> Handle(GetEmployeeByAgeQuery request, CancellationToken cancellationToken)
        {
            return await unitOfWork.Employees.find(emp=>emp.Age<request.age);
        }
    }
}
