using BookRate.DAL.Models;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface ICommentaryRepository : IRepository<Commentary>
    {
        bool IsAnyCommentaryLikeReferenced(int commentaryId);
    }
}
