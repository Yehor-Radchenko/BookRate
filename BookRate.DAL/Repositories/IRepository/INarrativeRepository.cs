using BookRate.DAL.Models;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface INarrativeRepository : IRepository<Narrative>
    {
        bool IsAnyBookReferenced(int narrativeId);
        bool IsAnyNarrativeRewardReferenced(int narrativeId);
        bool IsAnyContributorReferenced(int narrativeId);
        bool IsAnyGenreReferenced(int narrativeId);
        bool IsAnySettingReferenced(int narrativeId);
    }
}
