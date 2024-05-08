using BookRate.DAL.Models;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface ICommentaryLikeRepository
    {
        Task<CommentaryLike?> GetByIdAsync(int id);
        Task<IEnumerable<CommentaryLike>> GetAllAsync();
        Task<bool> Add(CommentaryLike entity);
        Task<bool> Delete(CommentaryLike entity);
    }
}
