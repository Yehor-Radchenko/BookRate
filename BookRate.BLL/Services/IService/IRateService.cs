using BookRate.BLL.ViewModels.Rate;
using BookRate.DAL.DTO;
using BookRate.DAL.DTO.Rate;

namespace BookRate.BLL.Services.IService
{
    public interface IRateService
    {
        Task<bool> Add(CreateRateDTO dto);
        Task<bool> Update(UpdateRateDTO expectedEntityValues);
        Task<bool> Delete(int id);
        Task<IEnumerable<RateViewModel>> GetAll();
        Task<RateViewModel?> GetById(int? id);
    }
}
