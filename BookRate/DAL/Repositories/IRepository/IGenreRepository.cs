using BookRate.DAL.Models;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface IGenreRepository : IRepository<Genre>
    {
        bool IsAnyNarrativeReferenced(int genreId);
        bool IsGenreWithNameExists(string name);
    }
}
