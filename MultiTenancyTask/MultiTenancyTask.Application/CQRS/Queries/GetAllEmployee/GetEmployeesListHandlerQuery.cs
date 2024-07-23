using MultiTenancyTask.Domain.Entities;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenancyTask.Domain.Repositories;
using MultiTenancyTask.Domain.Interface;

namespace MultiTenancyTask.Domain.CQRS.Queries.GetAllEmployee
{
    public class GetEmployeesListHandlerQuery : IRequestHandler<GetAllEmployeesQuery, List<Employee>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetEmployeesListHandlerQuery(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public async Task<List<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await unitOfWork.Employees.GetAll();
        }
    }
}
