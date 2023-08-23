using EmployeeManagement.Domain.Common.Dtos.Response;
using EmployeeManagement.Repository.Contracts.Dtos.Department.Request;
using EmployeeManagement.Repository.Contracts.Dtos.Employee.Request;
using EmployeeManagement.Service.Contracts.Dtos.Employee.Request;
using EmployeeManagement.Service.Contracts.Dtos.Employee.Response;

namespace EmployeeManagement.Service.Contracts.Services
{
    public interface IEmployeeService
    {
        Task CreateAsync(EmployeeCreateRequest request);

        Task EditAsync(EmployeeEditRequest request);

        Task DeleteByIdAsync(int id);

        Task<EmployeeResponse> GetByIdAsync(int id);

        Task<List<EmployeeResponse>> GetAllAsync();

        Task<PageListResponse<EmployeeResponse>> GetAllAsync(AllEmployeePageRequest request);
    }
}
