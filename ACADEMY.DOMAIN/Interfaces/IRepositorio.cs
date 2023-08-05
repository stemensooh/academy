using System.Linq.Expressions;

namespace ACADEMY.DOMAIN.Interfaces
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        int Count();

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    }
}