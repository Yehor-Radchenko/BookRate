using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetAsync(Expression<Func<T, bool>>? filter = null, string? includeOptions = null);
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeOptions = null);
        IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeOptions = null);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> Delete(T entity);
        bool Exists(Expression<Func<T, bool>> predicate);
    }
}
