using EmployeeManagement.Domain.Common.Dtos.Response;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Repository.Contracts.Dtos.Department.Request;
using EmployeeManagement.Repository.Contracts.Dtos.Employee.Request;

namespace EmployeeManagement.Repository.Contracts.Repositories
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        Task<PageListResponse<Department>> GetAllAsync(AllDepartmentPageRequest request);

    }
}