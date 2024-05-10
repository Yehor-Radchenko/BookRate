using BookRate.DAL.Repositories.IRepository.EntitiesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenreRepository GenreRepository { get; }
        Task<bool> CommitAsync();
    }
}
