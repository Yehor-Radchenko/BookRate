using AutoMapper;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.Setting;
using BookRate.DAL.DTO.Setting;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.BLL.Services
{
    public class SettingService : BaseService, IService<CreateSettingDTO, UpdateSettingDTO, Setting>
    {
        public SettingService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> AddAsync(CreateSettingDTO dto)
        {
            var settingRepo = _unitOfWork.GetRepository<Setting>();

            if (settingRepo.Exists(s => s.Name.ToLower() == dto.Name.ToLower()))
                throw new Exception($"Setting named {dto.Name} is already exists in database.");

            var settingModel = _mapper.Map<Setting>(dto);

            await settingRepo.AddAsync(settingModel);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var settingRepo = _unitOfWork.GetRepository<Setting>();

            if (settingRepo.Exists(s => s.Id == id && s.Narratives.Any()))
                throw new Exception("Setting cant be removed because it referenced by at least one narrative.");

            await settingRepo.Delete(new Setting { Id = id });
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<SettingViewModel?> GetByIdAsync(int? id)
        {
            var settingRepo = _unitOfWork.GetRepository<Setting>();

            Setting? settingModel = await settingRepo.GetAsync(g => g.Id == id);

            if (settingModel is null)
                throw new Exception($"There is no model with Id {id}");

            return _mapper.Map<SettingViewModel>(settingModel);
        }

        public async Task<bool> UpdateAsync(UpdateSettingDTO expectedEntityValues)
        {
            var settingRepo = _unitOfWork.GetRepository<Setting>();

            if (settingRepo.Exists(g => g.Name.ToLower() == expectedEntityValues.Name.ToLower()))
                throw new Exception($"Setting named {expectedEntityValues.Name} is already exists in database.");

            var settingModel = _mapper.Map<Setting>(expectedEntityValues);

            await settingRepo.UpdateAsync(settingModel);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<IEnumerable<SettingListModel>> GetSettingListModelsAsync()
        {
            var settingRepository = _unitOfWork.GetRepository<Setting>();

            var list = await settingRepository.GetAllAsync();

            var getMappedList = _mapper.Map<IEnumerable<SettingListModel>>(list);

            return getMappedList;
        }
    }
}
