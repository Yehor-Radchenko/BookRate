using BookRate.DAL.Context;
using BookRate.DAL.Repositories.EntityImplementations;
using BookRate.DAL.Repositories.IRepository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BookRate.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookRateDbContext _dbContext;
        public IGenreRepository GenreRepository { get; private set; }
        public UnitOfWork(BookRateDbContext dbContext)
        {
            _dbContext = dbContext;
            GenreRepository = new GenreRepository(dbContext);
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
        }
    }
}
