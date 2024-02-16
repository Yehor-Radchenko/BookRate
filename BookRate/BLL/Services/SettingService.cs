using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services
{
    public class SettingService : ISettingService
    {
        public Task<bool> Create(SettingDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SettingViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SettingViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(SettingDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
