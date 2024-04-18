using BookRate.DAL.Models;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface ISettingRepository : IRepository<Setting>
    {
        bool IsAnyNarrativeReferenced(int genreId);
        bool IsSettingWithNameExists(string name);
    }
}
