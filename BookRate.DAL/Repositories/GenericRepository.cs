using BookRate.DAL.Context;
using BookRate.DAL.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected BookRateDbContext _bookRateDbContext;
        protected DbSet<T> _dbSet;
        public GenericRepository(BookRateDbContext bookRateDbContext
            )
        {
            _bookRateDbContext = bookRateDbContext;
            _dbSet = _bookRateDbContext.Set<T>();

        }

        public async Task<bool> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        public virtual async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeOptions = null)
        {

            IQueryable<T> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (includeOptions != null)
            {
                foreach (var entity in includeOptions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(entity);
                }
            }

            return await Task.FromResult(query);
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeOptions = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (includeOptions != null)
            {
                foreach (var entity in includeOptions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(entity);
                }
            }

            return query;
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>>? filter = null, string? includeOptions = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeOptions != null)
            {
                foreach (var entity in includeOptions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(entity);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                return true;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }
    }
}
