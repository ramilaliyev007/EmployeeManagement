using EmployeeManagement.Domain.Common.Exceptions;
using EmployeeManagement.Repository.Contracts;
using EmployeeManagement.Repository.Contracts.Repositories;
using EmployeeManagement.Repository.EfCore.DbContexts;
using EmployeeManagement.Repository.EfCore.Helpers;
using EmployeeManagement.Repository.EfCore.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int> CommitAsync()
        {
            try
            {
                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException { Number: SqlExceptionNumberConsts.DuplicateKey or SqlExceptionNumberConsts.UniqueConstraint })
            {
                throw new UniqueConstraintException(innerException: ex);
            }
            catch
            {
                throw;
            }
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
