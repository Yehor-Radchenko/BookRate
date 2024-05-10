using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Expression<Func<T, bool>>? filter = null, string? includeOptions = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeOptions = null);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> Delete(T entity);
    }
}
