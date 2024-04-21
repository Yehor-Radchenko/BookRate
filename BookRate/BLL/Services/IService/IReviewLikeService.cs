using BookRate.BLL.ViewModels;

namespace BookRate.BLL.Services.IService
{
    public interface IReviewLikeService
    {
        Task<bool> Add(CreateReviewLikeDTO dto);
        Task<bool> Delete(int id);
        Task<IEnumerable<ReviewLikeViewModel>> GetAll();
        Task<ReviewLikeViewModel?> GetById(int? id);
    }
}
