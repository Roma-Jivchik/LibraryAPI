using System.Linq.Expressions;
using WebLibrary.Domain.Entities;

namespace WebLibrary.DAL
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task<List<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);

        Task<TEntity?> GetByIdAsync(Guid id);

        Task<TEntity> AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(TEntity entity);
    }
}
