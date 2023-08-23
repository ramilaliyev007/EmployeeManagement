using EmployeeManagement.Domain.Common.Dtos.Response;
using EmployeeManagement.Repository.Contracts.Dtos.Department.Request;
using EmployeeManagement.Repository.Contracts.Dtos.Employee.Request;
using EmployeeManagement.Service.Contracts.Dtos.Department.Request;
using EmployeeManagement.Service.Contracts.Dtos.Department.Response;

namespace EmployeeManagement.Service.Contracts.Services
{
    public interface IDepartmentService
    {
        Task CreateAsync(DepartmentCreateRequest request);

        Task EditAsync(DepartmentEditRequest request);

        Task DeleteByIdAsync(int id);

        Task<DepartmentResponse> GetByIdAsync(int id);

        Task<List<DepartmentResponse>> GetAllAsync();

        Task<PageListResponse<DepartmentResponse>> GetAllAsync(AllDepartmentPageRequest request);
    }
}
