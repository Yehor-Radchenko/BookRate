using BookRate.DAL.Models;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface IReviewRepository : IRepository<Review>
    {
        bool IsReviewWithTitleExists(string title);
    }
}
