using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Repository.Contracts.Repositories;
using EmployeeManagement.Repository.EfCore.DbContexts;

namespace EmployeeManagement.Repository.EfCore.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(EmployeeManagementDbContext dbContext) : base(dbContext)
        {

        }
    }
}
