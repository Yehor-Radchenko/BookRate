using BookRate.DAL.Models;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface IShelfRepository : IRepository<Shelf>
    {
        bool IsShelfWithNameExists(string name);
    }
}
