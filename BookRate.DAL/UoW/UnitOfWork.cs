using BookRate.DAL.Context;
using BookRate.DAL.Repositories;
using BookRate.DAL.Repositories.EntityImplementations;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookRateDbContext _dbContext;
        private Dictionary<Type, object>? _repos;


        public IRestrictRepository RestrictRepository =>
                (IRestrictRepository)GetRepository<RestrictRepository>();

        public IUserRepository UserRepository => 
            (IUserRepository)GetRepository<UserRepository>();
   

        public UnitOfWork(BookRateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IGenericRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            if (_repos == null)
            {
                _repos = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!_repos.ContainsKey(type))
            {
                _repos[type] = new GenericRepository<TEntity>(_dbContext);
            }

            return (IGenericRepository<TEntity>)_repos[type];
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
