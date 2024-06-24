using AutoMapper;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.Genre;
using BookRate.DAL.DTO.Contributor;
using BookRate.DAL.DTO.Genre;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
using FluentValidation;
using FluentValidation.Results;

namespace BookRate.BLL.Services
{
    public class GenreService : BaseService<Genre, GenreDto>, IService<GenreDto>
    {
        public GenreService(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IValidator<GenreDto> validator
            ) : base(unitOfWork, mapper, validator)
        {
        }

        public async Task<int> AddAsync(GenreDto dto)
        {
            ValidationResult result = await _validator.ValidateAsync(dto);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var genreRepo = _unitOfWork.GetRepository<Genre>();

            if (await genreRepo.ExistsAsync(g => g.Name.ToLower() == dto.Name.ToLower()))
                throw new Exception($"Genre named {dto.Name} is already exists in database.");
            
            var genreModel = _mapper.Map<Genre>(dto);

            await genreRepo.AddAsync(genreModel);
            await _unitOfWork.CommitAsync();
            return genreModel.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var genreRepo = _unitOfWork.GetRepository<Genre>();
            var genreExists = await genreRepo.GetAsync(c => c.Id == id);

            if (genreExists is null)
                throw new Exception("Genre can't be found.");

            await genreRepo.DeleteAsync(genreExists);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<GenreViewModel?> GetByIdAsync(int? id)
        {
            var genreRepo = _unitOfWork.GetRepository<Genre>();

            Genre? genreModel = await genreRepo.GetAsync(g => g.Id == id);

            if (genreModel is null)
                throw new ArgumentException($"There is no model with Id {id}");

            return _mapper.Map<GenreViewModel>(genreModel);
        }

        public async Task<bool> UpdateAsync(int id, GenreDto expectedEntityValues)
        {
            ValidationResult result = await _validator.ValidateAsync(expectedEntityValues);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var genreRepo = _unitOfWork.GetRepository<Genre>();

            if (await genreRepo.ExistsAsync(g => g.Name.ToLower() == expectedEntityValues.Name.ToLower()))
                throw new Exception($"Genre named {expectedEntityValues.Name} is already exists in database.");

            var genreModel = _mapper.Map<Genre>(expectedEntityValues);
            genreModel.Id = id;

            await genreRepo.UpdateAsync(genreModel);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<IEnumerable<GenreListModel>> GetGenreListModelsAsync()
        {
            var genreRepository = _unitOfWork.GetRepository<Genre>();

            var list = await genreRepository.GetAllAsync();

            var getMappedList = _mapper.Map<IEnumerable<GenreListModel>>(list);

            return getMappedList;
        }
    }
}
