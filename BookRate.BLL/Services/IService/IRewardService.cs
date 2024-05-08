using BookRate.BLL.ViewModels.Reward;
using BookRate.DAL.DTO;
using BookRate.DAL.DTO.Reward;

namespace BookRate.BLL.Services.IService
{
    public interface IRewardService
    {
        Task<bool> Add(CreateRewardDTO dto);
        Task<bool> Update(UpdateRewardDTO expectedEntityValues);
        Task<bool> Delete(int id);
        Task<IEnumerable<RewardViewModel>> GetAll();
        Task<RewardViewModel?> GetById(int? id);
    }
}
