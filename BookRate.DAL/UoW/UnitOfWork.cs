using BookRate.DAL.Context;
using BookRate.DAL.Repositories;
using BookRate.DAL.Repositories.EntityImplementations;
using BookRate.DAL.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BookRate.DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookRateDbContext _dbContext;
        private Dictionary<Type, object>? repos;
        public UnitOfWork(BookRateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            if (repos == null)
            {
                repos = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!repos.ContainsKey(type))
            {
                repos[type] = new GenericRepository<TEntity>(_dbContext);
            }

            return (IGenericRepository<TEntity>)repos[type];
        }

        public async Task<bool> CommitAsync()
        {
            var result = await _dbContext.SaveChangesAsync();
            if (result == 0)
                return false;

            return true;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(obj: this);
        }
    }
}
