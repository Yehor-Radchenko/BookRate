using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services.IService
{
    public interface IReviewLikeService
    {
        Task<bool> Add(CreateReviewLikeDTO dto);
        Task<bool> Delete(int id);
    }
}
