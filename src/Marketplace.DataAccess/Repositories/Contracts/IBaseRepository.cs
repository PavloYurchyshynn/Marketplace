using Marketplace.Core.Common;
using System.Linq.Expressions;

namespace Marketplace.DataAccess.Repositories.Contracts
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate);
    }
}
