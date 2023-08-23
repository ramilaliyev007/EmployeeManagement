using EmployeeManagement.Domain.Common.Dtos.Requests;
using EmployeeManagement.Domain.Common.Dtos.Response;
using EmployeeManagement.Domain.Common.Exceptions;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Repository.Contracts.Repositories;
using EmployeeManagement.Repository.EfCore.DbContexts;
using EmployeeManagement.Repository.EfCore.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository.EfCore.Repositories
{

    public class BaseRepository<TEntity> : BaseRepository<TEntity, int>
         where TEntity : Entity, new()
    {
        public BaseRepository(EmployeeManagementDbContext dbContext) : base(dbContext)
        {

        }
    }

    public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
        where TEntity : Entity<TId>, new()
        where TId : struct
    {
        protected readonly EmployeeManagementDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(EmployeeManagementDbContext dbContext)
        {
            _dbContext = dbContext;

            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw new InvalidForeignKeyException(innerException: ex);
            }
        }

        public virtual async Task DeleteByIdAsync(TId id)
        {
            var entity = await GetByIdAsync(id);

            DataNotFoundByIdException.ThrowIfNotFound(entity, id);

            _dbSet.Remove(entity!);

            await Task.CompletedTask;
        }

        public virtual Task EditAsync(TEntity entity)
        {
            _dbSet.Update(entity);

            return Task.CompletedTask;
        }

        public async Task<bool> ExistsById(TId id)
        {
            return await _dbSet.AnyAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<PageListResponse<TEntity>> GetAllAsync(PageRequest pageRequest)
        {
            var totalCount = await _dbSet.CountAsync();

            // PageBy is extension method
            // For more information, see the QueryableExtensions.cs file
            var entities = await _dbSet.PageBy<TEntity, TId>(pageRequest)
                                       .AsNoTracking()
                                       .ToListAsync();

            var result = new PageListResponse<TEntity>(pageRequest.PageSize, totalCount, entities);

            return result;
        }

        public virtual async Task<TEntity?> GetByIdAsync(TId id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
