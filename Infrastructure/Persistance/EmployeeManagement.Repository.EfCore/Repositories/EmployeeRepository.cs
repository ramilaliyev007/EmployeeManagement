﻿using EmployeeManagement.Domain.Common.Dtos.Response;
using EmployeeManagement.Domain.Common.Extension;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Repository.Contracts.Dtos.Employee.Request;
using EmployeeManagement.Repository.Contracts.Repositories;
using EmployeeManagement.Repository.EfCore.DbContexts;
using EmployeeManagement.Repository.EfCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository.EfCore.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeManagementDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<PageListResponse<Employee>> GetAllAsync(AllEmployeePageRequest request)
        {
            // WhereIf and PageBy are extension method
            // For more information, see the QueryableExtensions.cs file

            var query = _dbSet.Include(x => x.Department)
                              .WhereIf(request.DepartmentId.HasValue, x => x.DepartmentId == request.DepartmentId)
                              .WhereIf(!request.Name.IsNullOrEmpty(), x => EF.Functions.Like(x.Name, $"%{request.Name}%"))
                              .WhereIf(!request.Surname.IsNullOrEmpty(), x => EF.Functions.Like(x.Surname, $"%{request.Surname}%"))
                              .WhereIf(request.CreatedDateStart.HasValue && request.CreatedDateEnd.HasValue, x => x.CreatedDate >= request.CreatedDateStart &&
                                                                                                                  x.CreatedDate <= request.CreatedDateEnd)
                              .WhereIf(request.BirthDateStart.HasValue && request.BirthDateEnd.HasValue, x => x.BirthDate >= request.BirthDateStart &&
                                                                                                              x.BirthDate <= request.BirthDateEnd);

            var totalCount = await query.CountAsync();

            var employees = await query.PageBy(request)
                                       .AsNoTracking()
                                       .ToListAsync();

            var result = new PageListResponse<Employee>(request.PageSize, totalCount, employees);

            return result;
        }

        public async override Task<List<Employee>> GetAllAsync()
        {
            return await _dbSet.Include(x => x.Department)
                               .AsNoTracking()
                               .ToListAsync();
        }

        public override async Task<Employee?> GetByIdAsync(int id)
        {
            return await _dbSet.Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteAllByDepartmentIdAsync(int departmentId)
        {
            // TODO: For better performance, use bulk delete (ExecuteDelete) after upgrade EF version to 7.0.0

            var employees = await _dbSet.Where(x => x.DepartmentId == departmentId).ToListAsync();

            _dbSet.RemoveRange(employees);
        }
    }
}
