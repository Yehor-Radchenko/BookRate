using AutoMapper;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.Setting;
using BookRate.DAL.DTO.Setting;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
using FluentValidation;
using FluentValidation.Results;

namespace BookRate.BLL.Services
{
    public class SettingService : BaseService<Setting, SettingDto>
    {
        public SettingService(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IValidator<SettingDto> validator
            ) : base(unitOfWork, mapper, validator)
        {
        }

        public async Task<int> AddAsync(SettingDto dto)
        {
            ValidationResult result = await _validator.ValidateAsync(dto);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var settingRepo = _unitOfWork.GetRepository<Setting>();

            if (settingRepo.Exists(s => s.Name.ToLower() == dto.Name.ToLower()))
                throw new Exception($"Setting named {dto.Name} is already exists in database.");

            var settingModel = _mapper.Map<Setting>(dto);

            await settingRepo.AddAsync(settingModel);
            await _unitOfWork.CommitAsync();
            return settingModel.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var settingRepo = _unitOfWork.GetRepository<Setting>();

            Setting? settingToDelete = await settingRepo.GetAsync(g => g.Id == id);

            if (settingToDelete is null)
                throw new ArgumentException($"There is no model with Id {id}", nameof(id));

            await settingRepo.DeleteAsync(settingToDelete);
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

        public async Task<bool> UpdateAsync(int id, SettingDto expectedEntityValues)
        {
            ValidationResult result = await _validator.ValidateAsync(expectedEntityValues);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

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
