using EmployeeManagement.Domain.Common.Dtos.Response;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Repository.Contracts.Dtos.Employee.Request;

namespace EmployeeManagement.Repository.Contracts.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<PageListResponse<Employee>> GetAllAsync(AllEmployeePageRequest request);

        Task DeleteAllByDepartmentIdAsync(int departmentId);
    }
}