using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.BLL.Services
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IMapper _mapper;

        public SettingService(ISettingRepository settingRepository, IMapper mapper)
        {
            _settingRepository = settingRepository;
            _mapper = mapper;
        }

        public async Task<bool> Add(CreateSettingDTO dto)
        {
            if (_settingRepository.IsSettingWithNameExists(dto.Name))
                throw new Exception($"Setting named {dto.Name} is already exists in database.");

            try
            {
                var model = _mapper.Map<Setting>(dto);
                await _settingRepository.Add(model);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            if (_settingRepository.IsAnyNarrativeReferenced(id))
                throw new Exception("Setting can't be removed because it referenced by at least one narrative.");

            try
            {
                await _settingRepository.Delete(new Setting { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<SettingViewModel>> GetAll()
        {
            try
            {
                IEnumerable<Setting> models = await _settingRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<SettingViewModel>>(models);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving setting.", ex);
            }
        }

        public async Task<SettingViewModel?> GetById(int? id)
        {
            if (id == null)
                throw new Exception("Id is null.");

            try
            {
                Setting? model = await _settingRepository.GetByIdAsync(id.Value);

                if (model == null)
                    throw new Exception($"There is no setting with Id {id}");

                return _mapper.Map<SettingViewModel>(model);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving setting.", ex);
            }
        }

        public async Task<bool> Update(UpdateSettingDTO expectedEntityValues)
        {
            if (_settingRepository.IsSettingWithNameExists(expectedEntityValues.Name))
                throw new Exception($"Setting named {expectedEntityValues.Name} is already exists in database.");

            try
            {
                Setting model = _mapper.Map<Setting>(expectedEntityValues);

                await _settingRepository.Update(model);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating setting.", ex);
            }
        }
    }
}
