using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.Repositories.EntityImplementations
{


    public class RestrictRepository : GenericRepository<Restrict>, IRestrictRepository
    {
        public RestrictRepository(BookRateDbContext bookRateDbContext) : base(bookRateDbContext)
        { }
      

        public async Task<DateTime> BanExpirationAsync(int userId)
        {
            return await _dbSet.Where(e => e.UserId == userId)
                .Select(e => e.BanRemovalDate)
                .FirstOrDefaultAsync();
        }
    }


}
