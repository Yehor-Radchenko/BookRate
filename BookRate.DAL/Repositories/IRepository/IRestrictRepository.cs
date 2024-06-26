﻿using BookRate.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface IRestrictRepository : IGenericRepository<Restrict>
    {
        Task<DateTime> BanExpirationAsync(int userId);
    }
}
