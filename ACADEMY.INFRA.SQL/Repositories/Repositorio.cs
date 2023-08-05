using ACADEMY.DOMAIN.Interfaces;
using ACADEMY.INFRA.SQL.Data;
using ACADEMY.INFRA.UOW.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ACADEMY.INFRA.UOW.Repositories
{
    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        protected readonly AcademyContext _context;
        protected readonly DbSet<TEntity> _entities;

        public Repositorio(AcademyContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public int Count()
        {
            return _entities.Count();
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.FirstOrDefault(predicate);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.AnyAsync(predicate);
        }

        public Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate).ToListAsync();
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.FirstOrDefaultAsync(predicate);
        }
    }
}