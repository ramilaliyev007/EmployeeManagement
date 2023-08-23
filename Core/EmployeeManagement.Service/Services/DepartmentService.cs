using EmployeeManagement.Domain.Common.Dtos.Response;
using EmployeeManagement.Domain.Common.Exceptions;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Repository.Contracts;
using EmployeeManagement.Repository.Contracts.Dtos.Department.Request;
using EmployeeManagement.Repository.Contracts.Dtos.Employee.Request;
using EmployeeManagement.Service.Contracts.Dtos.Department.Request;
using EmployeeManagement.Service.Contracts.Dtos.Department.Response;
using EmployeeManagement.Service.Contracts.Services;
using Mapster;

namespace EmployeeManagement.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(DepartmentCreateRequest request)
        {
            var department = request.Adapt<Department>();

            await _unitOfWork.Departments.CreateAsync(department);

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _unitOfWork.Departments.DeleteByIdAsync(id);

            await _unitOfWork.Employees.DeleteAllByDepartmentIdAsync(id);

            await _unitOfWork.CommitAsync();
        }

        public async Task EditAsync(DepartmentEditRequest request)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(request.Id);

            DataNotFoundByIdException.ThrowIfNotFound(department, request.Id);

            request.Adapt(department);

            await _unitOfWork.Departments.EditAsync(department);

            await _unitOfWork.CommitAsync();
        }

        public async Task<List<DepartmentResponse>> GetAllAsync()
        {
            var resultInternal = await _unitOfWork.Departments.GetAllAsync();

            var result = resultInternal.Adapt<List<DepartmentResponse>>();

            return result;
        }

        public async Task<PageListResponse<DepartmentResponse>> GetAllAsync(AllDepartmentPageRequest request)
        {
            var resultInternal = await _unitOfWork.Departments.GetAllAsync(request);

            var departments = resultInternal.List.Adapt<List<DepartmentResponse>>();

            var result = new PageListResponse<DepartmentResponse>(request.PageSize, resultInternal.TotalCount, departments);

            return result;
        }

        public async Task<DepartmentResponse> GetByIdAsync(int id)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);

            DataNotFoundByIdException.ThrowIfNotFound(department, id);

            var result = department!.Adapt<DepartmentResponse>();

            return result;
        }
    }
}
