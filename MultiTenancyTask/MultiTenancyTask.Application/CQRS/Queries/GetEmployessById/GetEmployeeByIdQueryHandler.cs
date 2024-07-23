using MultiTenancyTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenancyTask.Domain.Repositories;
using MultiTenancyTask.Domain.CQRS.Queries.GetEmployessById;
using MultiTenancyTask.Domain.Interface;

namespace MultiTenancyTask.Domain.CQRS.Queries.GetEmployessByAge
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetEmployeeByIdQueryHandler(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await unitOfWork.Employees.GetById(request.id);
        }
    }
}
