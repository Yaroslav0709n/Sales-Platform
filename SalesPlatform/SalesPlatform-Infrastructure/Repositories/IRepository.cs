using System.Linq.Expressions;

namespace SalesPlatform_Infrastructure.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<int> SaveChangesAsync();
        ValueTask<TEntity> GetByIdAsync(params object[] keys);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Delete(TEntity entity);
    }
}
