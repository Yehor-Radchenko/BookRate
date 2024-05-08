using BookRate.DAL.Models;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface IRewardRepository : IRepository<Reward>
    {
        bool IsAnyNarrativeRewardReferenced(int revardId);
    }
}
