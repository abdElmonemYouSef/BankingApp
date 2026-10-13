using BankingApp.Data;
using BankingApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BankingApp.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    if (include != null)
                    {
                        query = query.Include(include);
                    }
                }
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>>[]? filters = null,  Expression<Func<T, object>>[]? includes = null)
        {
            IQueryable<T> query = _dbSet;

            // 1. تطبيق الـ Includes لجلب العلاقات
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    if (include != null)
                    {
                        query = query.Include(include);
                    }
                }
            }

            // 2. تطبيق الفلاتر المتعددة بطريقة صحيحة عبر الـ Loop
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    if (filter != null)
                    {
                        query = query.Where(filter);
                    }
                }
            }

            return await query.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}