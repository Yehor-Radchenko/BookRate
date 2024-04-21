using BookRate.BLL.ViewModels;

namespace BookRate.BLL.Services.IService
{
    public interface ICommentaryLikeService
    {
        Task<bool> Add(CreateCommentaryLikeDTO dto);
        Task<bool> Update(UpdateCommentaryLikeDTO expectedEntityValues);
        Task<bool> Delete(int id);
        Task<IEnumerable<CommentaryLikeViewModel>> GetAll();
    }
}
