using EmployeeManagement.Repository.Contracts;
using EmployeeManagement.Repository.Contracts.Repositories;
using EmployeeManagement.Repository.EfCore.DbContexts;
using EmployeeManagement.Repository.EfCore.Repositories;

namespace EmployeeManagement.Repository.EfCore
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IEmployeeRepository _employeeRepository;
        private IDepartmentRepository _departmentRepository;

        private readonly EmployeeManagementDbContext _dbContext;

        private bool disposed = false;

        public UnitOfWork(EmployeeManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEmployeeRepository Employees
        {
            get
            {
                if (_employeeRepository is null)
                {
                    _employeeRepository = new EmployeeRepository(_dbContext);
                }

                return _employeeRepository;
            }
        }

        public IDepartmentRepository Departments
        {
            get
            {
                if (_departmentRepository is null)
                {
                    _departmentRepository = new DepartmentRepository(_dbContext);
                }

                return _departmentRepository;
            }
        }

        public Task<int> CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            disposed = true;
        }
    }
}
