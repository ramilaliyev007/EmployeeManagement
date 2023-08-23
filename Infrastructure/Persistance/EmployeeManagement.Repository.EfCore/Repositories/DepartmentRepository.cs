using EmployeeManagement.Domain.Common.Dtos.Response;
using EmployeeManagement.Domain.Common.Extension;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Repository.Contracts.Dtos.Department.Request;
using EmployeeManagement.Repository.Contracts.Repositories;
using EmployeeManagement.Repository.EfCore.DbContexts;
using EmployeeManagement.Repository.EfCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository.EfCore.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(EmployeeManagementDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<PageListResponse<Department>> GetAllAsync(AllDepartmentPageRequest request)
        {
            // WhereIf and PageBy are extension method
            // For more information, see the QueryableExtensions.cs file

            var query = _dbSet.WhereIf(!request.Name.IsNullOrEmpty(), x => EF.Functions.Like(x.Name, $"%{request.Name}%"))
                              .WhereIf(request.CreatedDateStart.HasValue && request.CreatedDateEnd.HasValue, x => x.CreatedDate >= request.CreatedDateStart &&
                                                                                                                  x.CreatedDate <= request.CreatedDateEnd);

            var totalCount = await query.CountAsync();

            var employees = await query.PageBy(request)
                                       .AsNoTracking()
                                       .ToListAsync();

            var result = new PageListResponse<Department>(request.PageSize, totalCount, employees);

            return result;
        }
    }
}
