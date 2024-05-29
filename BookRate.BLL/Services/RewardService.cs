using AutoMapper;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.Reward;
using BookRate.DAL.DTO.Reward;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.BLL.Services
{
    public class RewardService : BaseService, IService<CreateRewardDTO, UpdateRewardDTO, Reward>
    {
        public RewardService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<int> AddAsync(CreateRewardDTO dto)
        {
            var rewardRepo = _unitOfWork.GetRepository<Reward>();

            if (rewardRepo.Exists(r => r.Name.ToLower() == dto.Name.ToLower()))
                throw new Exception($"Reward named {dto.Name} is already exists in database.");

            var rewardModel = _mapper.Map<Reward>(dto);

            await rewardRepo.AddAsync(rewardModel);
            await _unitOfWork.CommitAsync();
            return rewardModel.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var rewardRepo = _unitOfWork.GetRepository<Reward>();

            if (rewardRepo.Exists(g => g.Id == id && g.NarrativeRewards.Any()))
                throw new Exception("Reward cant be removed because it referenced by at least one narrative.");

            await rewardRepo.Delete(new Reward { Id = id });
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(UpdateRewardDTO expectedEntityValues)
        {
            var rewardRepo = _unitOfWork.GetRepository<Reward>();

            if (rewardRepo.Exists(g => g.Name.ToLower() == expectedEntityValues.Name.ToLower()))
                throw new Exception($"Reward named {expectedEntityValues.Name} is already exists in database.");

            var rewardModel = _mapper.Map<Reward>(expectedEntityValues);

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
