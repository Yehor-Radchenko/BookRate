using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository.EntitiesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.Repositories.EntitiesImplementations
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(BookRateDbContext bookRateDbContext) 
            : base(bookRateDbContext)
        {
        }

    }
}
