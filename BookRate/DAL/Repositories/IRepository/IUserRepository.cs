using BookRate.DAL.Models;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        bool IsAnyCommentaryReferenced(int userId);
        bool IsAnyCommentaryLikeReferenced(int userId);
        bool IsAnyReviewReferenced(int userId);
        bool IsAnyReviewLikeReferenced(int userId);
        bool IsAnyRateReferenced(int userId);
        bool IsUserWithEmailExists(string email);
    }
}
