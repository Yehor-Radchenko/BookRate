﻿using AutoMapper;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.Reward;
using BookRate.DAL.DTO.Contributor;
using BookRate.DAL.DTO.Narrative;
using BookRate.DAL.DTO.Reward;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.BLL.Services
{
    public class RewardService : BaseService<Reward, RewardDto>, IService<RewardDto>
    {
        public RewardService(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IValidator<RewardDto> validator
            ) : base(unitOfWork, mapper, validator)
        {
        }

        public async Task<int> AddAsync(RewardDto dto)
        {
            ValidationResult result = await _validator.ValidateAsync(dto);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var rewardRepo = _unitOfWork.GetRepository<Reward>();

            if (await rewardRepo.ExistsAsync(r => r.Name.ToLower() == dto.Name.ToLower()))
                throw new InvalidOperationException($"Reward named {dto.Name} is already exists in database.");

            var rewardModel = _mapper.Map<Reward>(dto);

            await rewardRepo.AddAsync(rewardModel);
            await _unitOfWork.CommitAsync();
            return rewardModel.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var rewardRepo = _unitOfWork.GetRepository<Reward>();

            if (await rewardRepo.ExistsAsync(g => g.Id == id && g.NarrativeRewards.Any()))
                throw new Exception("Reward cant be removed because it referenced by at least one narrative.");

            await rewardRepo.DeleteAsync(new Reward { Id = id });
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, RewardDto expectedEntityValues)
        {
            ValidationResult result = await _validator.ValidateAsync(expectedEntityValues);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var rewardRepo = _unitOfWork.GetRepository<Reward>();

            if (await rewardRepo.ExistsAsync(g => g.Name.ToLower() == expectedEntityValues.Name.ToLower()))
                throw new Exception($"Reward named {expectedEntityValues.Name} is already exists in database.");

            var rewardModel = _mapper.Map<Reward>(expectedEntityValues);
            rewardModel.Id = id;

            await rewardRepo.UpdateAsync(rewardModel);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<RewardViewModel?> GetByIdAsync(int? id)
        {
            var rewardRepo = _unitOfWork.GetRepository<Reward>();

            Reward? rewardModel = await rewardRepo.GetAsync(g => g.Id == id);

            if (rewardModel is null)
                throw new Exception($"There is no model with Id {id}");

            return _mapper.Map<RewardViewModel>(rewardModel);
        }

        public async Task<IEnumerable<RewardListModel>> GetRewardListModelsAsync()
        {
            var rewardRepo = _unitOfWork.GetRepository<Reward>();

            var list = await rewardRepo.GetAllAsync();

            var getMappedList = _mapper.Map<IEnumerable<RewardListModel>>(list);

            return getMappedList;
        }
    }
}
