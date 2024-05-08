using BookRate.DAL.Models;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface ISerieRepository : IRepository<Serie>
    {
        bool IsAnyBookReferenced(int serieId);
        bool IsSerieWithNameExists(string name);
    }
}
