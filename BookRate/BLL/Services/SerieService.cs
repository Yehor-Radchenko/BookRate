using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.BLL.Services
{
    public class SerieService : ISerieService
    {
        private readonly ISerieRepository _serieRepository;
        private readonly IMapper _mapper;

        public SerieService(ISerieRepository serieRepository, IMapper mapper)
        {
            _serieRepository = serieRepository;
            _mapper = mapper;
        }

        public async Task<bool> Add(CreateSerieDTO dto)
        {
            if (_serieRepository.IsSerieWithNameExists(dto.Name))
                throw new Exception($"Serie named {dto.Name} is already exists in database.");

            try
            {
                var model = _mapper.Map<Serie>(dto);
                await _serieRepository.Add(model);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            if (_serieRepository.IsAnyBookReferenced(id))
                throw new Exception("Serie can't be removed because it referenced by at least one book.");

            try
            {
                await _serieRepository.Delete(new Serie { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<SerieViewModel>> GetAll()
        {
            try
            {
                IEnumerable<Serie> models = await _serieRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<SerieViewModel>>(models);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving serie.", ex);
            }
        }

        public async Task<SerieViewModel?> GetById(int? id)
        {
            if (id == null)
                throw new Exception("Id is null.");

            try
            {
                Serie? model = await _serieRepository.GetByIdAsync(id.Value);

                if (model == null)
                    throw new Exception($"There is no serie with Id {id}");

                return _mapper.Map<SerieViewModel>(model);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving serie.", ex);
            }
        }

        public async Task<bool> Update(UpdateSerieDTO expectedEntityValues)
        {
            if (_serieRepository.IsSerieWithNameExists(expectedEntityValues.Name))
                throw new Exception($"Serie named {expectedEntityValues.Name} is already exists in database.");

            try
            {
                Serie model = _mapper.Map<Serie>(expectedEntityValues);

                await _serieRepository.Update(model);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating serie.", ex);
            }
        }
    }
}
