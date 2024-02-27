using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;

namespace BookRate.BLL.Services
{
    public class SettingService : ISettingService
    {
        private readonly Repository<Setting> _settingRepository;
        private readonly IMapper _mapper;

        public SettingService(Repository<Setting> settingRepository, IMapper mapper)
        {
            _settingRepository = settingRepository;
            _mapper = mapper;
        }

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
