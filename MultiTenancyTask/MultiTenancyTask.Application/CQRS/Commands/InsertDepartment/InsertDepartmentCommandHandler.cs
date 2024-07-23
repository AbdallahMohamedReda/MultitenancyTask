using MultiTenancyTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenancyTask.Domain.Repositories;
using MultiTenancyTask.Domain.Interface;

namespace MultiTenancyTask.Application.CQRS.Commands.InsertDepartment
{
    public class InsertDepartmentCommandHandler : IRequestHandler<InsertDepartmentCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public InsertDepartmentCommandHandler(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public async Task<Unit> Handle(InsertDepartmentCommand request, CancellationToken cancellationToken)
        {
            if (request.DepartmentDTO != null)
            {
                Department Dept = new Department();
                Dept.Name = request.DepartmentDTO.Name;
                Dept.ManageName = request.DepartmentDTO.ManageName;
                await unitOfWork.Departments.add(Dept);
                await unitOfWork.complete();
            }
            return new Unit();
        }
    }
}
