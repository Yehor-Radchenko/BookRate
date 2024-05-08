using BookRate.BLL.ViewModels.Setting;
using BookRate.DAL.DTO;
using BookRate.DAL.DTO.Setting;

namespace BookRate.BLL.Services.IService
{
    public interface IShelfService
    {
        Task<bool> Add(CreateSettingDTO dto);
        Task<bool> Update(UpdateSettingDTO expectedEntityValues);
        Task<bool> Delete(int id);
        Task<IEnumerable<SettingViewModel>> GetAll();
        Task<SettingViewModel?> GetById(int? id);
    }
}
