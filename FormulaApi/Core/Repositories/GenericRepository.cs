﻿using FormulaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApiDbContext _context;
        protected DbSet<T> _dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(ApiDbContext context,
            ILogger logger)
        {
            _context = context;
            _logger = logger;
            this._dbSet = _context.Set<T>();
        }
        public virtual async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<bool> Delete(T entity)
        {
            _dbSet.Remove(entity);

            return true;
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Upate(T entity)
        {
            _dbSet.Update(entity);

            return true;
        }
    }
}
