using EmployeeManagement.Domain.Common.Dtos.Response;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Repository.Contracts;
using EmployeeManagement.Repository.Contracts.Dtos.Department.Request;
using EmployeeManagement.Repository.Contracts.Dtos.Employee.Request;
using EmployeeManagement.Service.Contracts.Dtos.Employee.Request;
using EmployeeManagement.Service.Contracts.Dtos.Employee.Response;
using EmployeeManagement.Service.Contracts.Services;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(EmployeeCreateRequest request)
        {
            var employee = request.Adapt<Employee>();

            await _unitOfWork.Employees.CreateAsync(employee);

            await _unitOfWork.CommitAsync();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(EmployeeEditRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PageListResponse<EmployeeResponse>> GetAllAsync(AllEmployeePageRequest request)
        {
            var employeeData = await _unitOfWork.Employees.GetAllAsync(request);

            var mappedEmployeeData = employeeData.List.Adapt<List<EmployeeResponse>>();

            var result = new PageListResponse<EmployeeResponse>(request.Take, employeeData.TotalCount, mappedEmployeeData);

            return result;
        }

        public Task<EmployeeResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
