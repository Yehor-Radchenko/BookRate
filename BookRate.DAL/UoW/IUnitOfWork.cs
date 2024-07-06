using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.DAL.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class;

        IRestrictRepository RestrictRepository { get; }

        IUserRepository UserRepository { get; }

        Task<bool> CommitAsync();
    }
}
