using EmployeeManagement.Repository.Contracts.Repositories;

namespace EmployeeManagement.Repository.Contracts
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }

        IDepartmentRepository Departments { get; }

        Task<int> CommitAsync();
    }
}
