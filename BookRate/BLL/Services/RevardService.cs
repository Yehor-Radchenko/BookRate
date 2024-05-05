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
    public class RevardService : IRevardService
    {
        private readonly IRevardRepository _revardRepository;
        private readonly IMapper _mapper;

        public RevardService(IRevardRepository revardRepository, IMapper mapper)
        {
            _revardRepository = revardRepository;
            _mapper = mapper;
        }

        public async Task<bool> Add(CreateRevardDTO dto)
        {
            try
            {
                var model = _mapper.Map<Revard>(dto);
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
                await _revardRepository.Delete(new Revard { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<RevardViewModel>> GetAll()
        {
            try
            {
                IEnumerable<Revard> models = await _revardRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<RevardViewModel>>(models);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving revard.", ex);
            }
        }

        public async Task<RevardViewModel?> GetById(int? id)
        {
            if (id == null)
                throw new Exception("Id is null.");

            try
            {
                Revard? model = await _revardRepository.GetByIdAsync(id.Value);

                if (model == null)
                    throw new Exception($"There is no revard with Id {id}");

                return _mapper.Map<RevardViewModel>(model);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving revard.", ex);
            }
        }

        public async Task<bool> Update(UpdateRevardDTO expectedEntityValues)
        {
            try
            {
                Revard model = _mapper.Map<Revard>(expectedEntityValues);

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
