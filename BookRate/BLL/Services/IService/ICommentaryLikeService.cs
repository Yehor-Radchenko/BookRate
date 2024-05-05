using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services.IService
{
    public interface ICommentaryLikeService
    {
        Task<bool> Add(CreateCommentaryLikeDTO dto);
        Task<bool> Delete(int id);
    }
}
