using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels.Edition;
using BookRate.DAL.DTO;
using BookRate.DAL.DTO.Edition;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.BLL.Services
{
    public class EditionService : IEditionService
    {
        private readonly IEditionRepository _editionRepository;
        private readonly IMapper _mapper;

        public EditionService(IEditionRepository editionRepository, IMapper mapper)
        {
            _editionRepository = editionRepository;
            _mapper = mapper;
        }

        public async Task<bool> Add(CreateEditionDTO dto)
        {
            try
            {
                var edition = _mapper.Map<Edition>(dto);
                await _editionRepository.Add(edition);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            if (_editionRepository.IsAnyBookEditionReferenced(id))
                throw new Exception("Edition can't be removed because it referenced by at least one BookEdition.");

            try
            {
                await _editionRepository.Delete(new Edition { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<EditionViewModel>> GetAll()
        {
            try
            {
                IEnumerable<Edition> editionModels = await _editionRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<EditionViewModel>>(editionModels);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving editions.", ex);
            }
        }

        public async Task<EditionViewModel?> GetById(int? id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Id is null.");

                Edition? model = await _editionRepository.GetByIdAsync(id.Value);

                if (model == null)
                    throw new Exception($"There is no model with Id {id}");

                return _mapper.Map<EditionViewModel>(model);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving edition.", ex);
            }
        }

        public async Task<bool> Update(UpdateEditionDTO expectedEntityValues)
        {
            try
            {
                var model = _mapper.Map<Edition>(expectedEntityValues);
                await _editionRepository.Update(model);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating edition.", ex);
            }
        }
    }
}
