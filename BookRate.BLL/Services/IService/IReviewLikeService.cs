using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;
using BookRate.DAL.DTO.ReviewLike;

namespace BookRate.BLL.Services.IService
{
    public interface IReviewLikeService
    {
        Task<bool> Add(CreateReviewLikeDTO dto);
        Task<bool> Delete(int id);
    }
}
