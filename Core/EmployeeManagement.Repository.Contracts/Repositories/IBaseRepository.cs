using EmployeeManagement.Domain.Common.Dtos.Requests;
using EmployeeManagement.Domain.Common.Dtos.Response;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Repository.Contracts.Repositories
{

    public interface IBaseRepository<TEntity> : IBaseRepository<TEntity, int>
        where TEntity : Entity, new()
    {

    }

    public interface IBaseRepository<TEntity, TId>
        where TEntity : Entity<TId>, new()
        where TId : struct
    {
        Task CreateAsync(TEntity entity);

        Task EditAsync(TEntity entity);

        Task<TEntity> GetByIdAsync(TId id);

        Task DeleteByIdAsync(TId id);

        Task<List<TEntity>> GetAllAsync();

        Task<PageListResponse<TEntity>> GetAllAsync(PageRequest pageRequest);
    }
}