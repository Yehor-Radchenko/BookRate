using BookRate.DAL.Models;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface IContributorRepository : IRepository<Contributor>
    {
        bool IsAnyNarrativeReferenced(int contributorId);
        bool IsAnyRoleReferenced(int contributorId);
    }
}
