using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services.IService
{
    public interface IReviewService
    {
        Task<bool> Add(CreateReviewDTO dto);
        Task<bool> Update(UpdateReviewDTO expectedEntityValues);
        Task<bool> Delete(int id);
        Task<IEnumerable<ReviewViewModel>> GetAll();
        Task<ReviewViewModel?> GetById(int? id);
    }
}
