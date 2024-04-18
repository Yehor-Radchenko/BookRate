using BookRate.DAL.Models;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface IReviewRepository : IRepository<Review>
    {
        bool IsAnyCommentaryReferenced(int reviewId);
        bool IsAnyReviewLikeReferenced(int reviewId);
        bool IsReviewWithTitleExists(string title);
    }
}
