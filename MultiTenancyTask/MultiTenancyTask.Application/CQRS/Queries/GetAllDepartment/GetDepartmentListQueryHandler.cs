using MultiTenancyTask.Domain.Entities;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenancyTask.Domain.Repositories;
using MultiTenancyTask.Domain.Interface;

namespace MultiTenancyTask.Domain.CQRS.Queries.GetAllDepartment
{
    public class GetDepartmentListQueryHandler : IRequestHandler<GetAllDepartmentsQuery, List<Department>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetDepartmentListQueryHandler(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public async Task<List<Department>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            return await unitOfWork.Departments.GetAll();
        }
    }
}
