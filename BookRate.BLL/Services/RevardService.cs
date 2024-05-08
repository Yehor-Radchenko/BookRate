using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels.Reward;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;
using BookRate.DAL.DTO.Reward;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.BLL.Services
{
    public class RewardService : IRewardService
    {
        private readonly IRewardRepository _revardRepository;
        private readonly IMapper _mapper;

        public RewardService(IRewardRepository revardRepository, IMapper mapper)
        {
            _revardRepository = revardRepository;
            _mapper = mapper;
        }

        public async Task<bool> Add(CreateRewardDTO dto)
        {
            try
            {
                var model = _mapper.Map<Reward>(dto);
                await _revardRepository.Add(model);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _revardRepository.Delete(new Reward { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<RewardViewModel>> GetAll()
        {
            try
            {
                IEnumerable<Reward> models = await _revardRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<RewardViewModel>>(models);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving revard.", ex);
            }
        }

        public async Task<RewardViewModel?> GetById(int? id)
        {
            if (id == null)
                throw new Exception("Id is null.");

            try
            {
                Reward? model = await _revardRepository.GetByIdAsync(id.Value);

                if (model == null)
                    throw new Exception($"There is no revard with Id {id}");

                return _mapper.Map<RewardViewModel>(model);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving revard.", ex);
            }
        }

        public async Task<bool> Update(UpdateRewardDTO expectedEntityValues)
        {
            try
            {
                Reward model = _mapper.Map<Reward>(expectedEntityValues);

                await _revardRepository.Update(model);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating revard.", ex);
            }
        }
    }
}
