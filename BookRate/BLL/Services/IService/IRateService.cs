using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

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
