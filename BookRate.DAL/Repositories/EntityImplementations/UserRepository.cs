using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.Repositories.EntityImplementations
{
    public  class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BookRateDbContext bookRateDbContext) 
            : base(bookRateDbContext)
        {
        }

        public UserRepository()
        {
            
        }
        
    }
}
