using BookRate.DAL.Models;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface IRevardRepository : IRepository<Revard>
    {
        bool IsAnyNarrativeRevardReferenced(int revardId);
    }
}
