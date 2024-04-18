using BookRate.DAL.Models;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface IShelfRepository : IRepository<Shelf>
    {
        bool IsAnyBookReferenced(int shelfId);
        bool IsShelfWithNameExists(string name);
    }
}
