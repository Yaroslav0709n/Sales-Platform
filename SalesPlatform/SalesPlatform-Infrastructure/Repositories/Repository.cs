﻿using Microsoft.EntityFrameworkCore;
using SalesPlatform_Infrastructure.Context;
using SalesPlatform_Infrastructure.Exceptions;
using System.Linq.Expressions;

namespace SalesPlatform_Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly ApplicationDbContext _сontext;
        private readonly DbSet<TEntity> _entities;

        public Repository(ApplicationDbContext сontext)
        {
            _сontext = сontext;
            _entities = _сontext.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            CheckEntityForNull(entity);
            return (await _entities.AddAsync(entity)).Entity;
        }

        public IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes)
        {
            var dbSet = _сontext.Set<TEntity>();
            var query = includes
                .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(dbSet, (current, include) => current.Include(include));

            return query ?? dbSet;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity) =>
            await Task.Run(() => _entities.Update(entity).Entity);

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _сontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (_сontext.Database.CurrentTransaction != null)
                {
                    await _сontext.Database.CurrentTransaction.RollbackAsync();
                }

                throw;
            }
        }

        public async ValueTask<TEntity> GetByIdAsync(params object[] keys) =>
            await _entities.FindAsync(keys) ?? throw new NotFoundException(_entities.EntityType.ToString(), keys.ToString());

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _entities.ToListAsync();

        public void Delete(TEntity entity) => _сontext.Entry(entity).State = EntityState.Deleted;

        private static void CheckEntityForNull(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "The entity to add cannot be null.");
            }
        }
    }
}