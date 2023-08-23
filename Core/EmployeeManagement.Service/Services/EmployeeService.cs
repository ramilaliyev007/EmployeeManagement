using EmployeeManagement.Domain.Common.Dtos.Response;
using EmployeeManagement.Domain.Common.Exceptions;
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

        public async Task DeleteByIdAsync(int id)
        {
            await _unitOfWork.Employees.DeleteByIdAsync(id);

            await _unitOfWork.CommitAsync();
        }

        public async Task EditAsync(EmployeeEditRequest request)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(request.Id);

            await ValidateOperandsForEditAsync(request, employee);

            request.Adapt(employee);

            await _unitOfWork.Employees.EditAsync(employee!);

            await _unitOfWork.CommitAsync();
        }

        public async Task<List<EmployeeResponse>> GetAllAsync()
        {
            var resultInternal = await _unitOfWork.Employees.GetAllAsync();

            var result = resultInternal.Adapt<List<EmployeeResponse>>();

            return result;
        }

        public async Task<PageListResponse<EmployeeResponse>> GetAllAsync(AllEmployeePageRequest request)
        {
            var resultInternal = await _unitOfWork.Employees.GetAllAsync(request);

            var employeeDtos = resultInternal.List.Adapt<List<EmployeeResponse>>();

            var result = new PageListResponse<EmployeeResponse>(request.Take, resultInternal.TotalCount, employeeDtos);

            return result;
        }

        public async Task<EmployeeResponse> GetByIdAsync(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);

            DataNotFoundByIdException.ThrowIfNotFound(employee, id);

            var result = employee!.Adapt<EmployeeResponse>();

            return result;
        }

        #region Privates

        private async Task ValidateOperandsForEditAsync(EmployeeEditRequest request, Employee? employee)
        {
            DataNotFoundByIdException.ThrowIfNotFound(employee, request.Id);

            if (!await _unitOfWork.Departments.ExistsById(request.DepartmentId))
            {
                throw new DataNotFoundByIdException("Department is not found", request.DepartmentId);
            }
        }

        #endregion
    }
}
