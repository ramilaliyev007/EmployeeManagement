using EmployeeManagement.Domain.Common.Dtos.Requests;
using EmployeeManagement.Domain.Common.Dtos.Response;
using EmployeeManagement.Domain.Common.Exceptions;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Repository.Contracts.Repositories;
using EmployeeManagement.Repository.EfCore.DbContexts;
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
            // TODO: Refactor this.
            // Remove Attach and use the ExecuteDeleteAsync after Upgrage EF Core version to 7.0.0

            TEntity entity = new()
            {
                Id = id
            };

            _dbSet.Attach(entity);

            _dbSet.Remove(entity);

            await Task.CompletedTask;
        }

        public async Task EditAsync(TEntity entity)
        {
            var entityInDb = await _dbSet.FindAsync(entity.Id);

            _dbContext.Entry(entityInDb).CurrentValues.SetValues(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<PageListResponse<TEntity>> GetAllAsync(PageRequest pageRequest)
        {
            var totalCount = await _dbSet.CountAsync();

            var entities = await _dbSet.Skip(pageRequest.Skip)
                                       .Take(pageRequest.Take)
                                       .ToListAsync();

            var result = new PageListResponse<TEntity>(pageRequest.Take, totalCount, entities);

            return result;
        }

        public async Task<TEntity> GetByIdAsync(TId id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
