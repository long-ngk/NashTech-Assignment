﻿using General.DataAccess.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace General.DataAccess.Business
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveAsync(object id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            var item = await dbSet.FirstOrDefaultAsync(filter);
            if (item == null)
                throw new ArgumentNullException("Null");
            return item;
        }

        public async Task<T> GetByIdAsync(object id)
        {
            var item = await dbSet.FindAsync(id);
            return item;
        }

        public async Task<IEnumerable<T>> GetAllWithSortedAsync(string sortOrder, Expression<Func<T, object>> filter)
        {
            IQueryable<T> categories;
            if (sortOrder == "Accsending")
            {
                categories = dbSet.OrderBy(filter);
            }
            else
            {
                categories = dbSet.OrderByDescending(filter);
            }
            return await categories.ToListAsync();
        }
    }
}
