using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels.Genre;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;
using BookRate.DAL.DTO.Genre;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.BLL.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<bool> Add(CreateGenreDTO genreDTO)
        {
            if (_genreRepository.IsGenreWithNameExists(genreDTO.Name))
                throw new Exception($"Genre named {genreDTO.Name} is already exists in database.");

            try
            {
                Genre genre = new Genre
                {
                    Name = genreDTO.Name,
                    Description = genreDTO.Description
                };

                await _genreRepository.Add(genre);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            if (_genreRepository.IsAnyNarrativeReferenced(id))
                throw new Exception("Genre cant be removed because it referenced by at least one narrative.");

            try
            {
                await _genreRepository.Delete(new Genre { Id = id});
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<GenreViewModel>> GetAll()
        {
            try
            {
                IEnumerable<Genre> genreModels = await _genreRepository.GetAllAsync();
                List<GenreViewModel> genreViewModels = new List<GenreViewModel>();

                foreach (var model in genreModels)
                {
                    GenreViewModel vm = new GenreViewModel
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Description = model.Description
                    };

                    genreViewModels.Add(vm);
                }

                return genreViewModels;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw new Exception("An error occurred while retrieving genres.", ex);
            }
        }


        public async Task<GenreViewModel?> GetById(int? id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Id is null.");

                Genre? genreModel = await _genreRepository.GetByIdAsync(id.Value);

                if (genreModel == null)
                    throw new Exception($"There is no model with Id {id}");

                return new GenreViewModel
                {
                    Id = genreModel.Id,
                    Name = genreModel.Name,
                    Description = genreModel.Description
                };
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw new Exception("An error occurred while retrieving the genre.", ex);
            }
        }

        public async Task<bool> Update(UpdateGenreDTO expectedEntityValues)
        {
            if (_genreRepository.IsGenreWithNameExists(expectedEntityValues.Name))
                throw new Exception($"Genre named {expectedEntityValues.Name} is already exists in database.");

            try
            {
                Genre genreModel = new Genre
                {
                    Id = expectedEntityValues.Id,
                    Name = expectedEntityValues.Name,
                    Description = expectedEntityValues.Description
                };

                await _genreRepository.Update(genreModel);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the genre.", ex);
            }
        }
    }
}
