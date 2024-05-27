﻿using AutoMapper;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.Genre;
using BookRate.DAL.DTO.Genre;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;

namespace BookRate.BLL.Services
{
    public class GenreService : BaseService, IService<CreateGenreDTO, UpdateGenreDTO, Genre>
    {
        public GenreService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> AddAsync(CreateGenreDTO dto)
        {
            var genreRepo = _unitOfWork.GetRepository<Genre>();

            if (genreRepo.Exists(g => g.Name.ToLower() == dto.Name.ToLower()))
                throw new Exception($"Genre named {dto.Name} is already exists in database.");
            
            var genreModel = _mapper.Map<Genre>(dto);

            await genreRepo.AddAsync(genreModel);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var genreRepo = _unitOfWork.GetRepository<Genre>();

            if (genreRepo.Exists(g => g.Id == id && g.Narratives.Any()))
                throw new Exception("Genre cant be removed because it referenced by at least one narrative.");

            if (genreRepo.Exists(g => g.Id == id && g.Contributors.Any()))
                throw new Exception("Genre cant be removed because it referenced by at least one contributor.");
            
            await genreRepo.Delete(new Genre { Id = id });
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<GenreViewModel?> GetByIdAsync(int? id)
        {
            var genreRepo = _unitOfWork.GetRepository<Genre>();

            Genre? genreModel = await genreRepo.GetAsync(g => g.Id == id);

            if (genreModel is null)
                throw new Exception($"There is no model with Id {id}");

            return _mapper.Map<GenreViewModel>(genreModel);
        }

        public async Task<bool> UpdateAsync(UpdateGenreDTO expectedEntityValues)
        {
            var genreRepo = _unitOfWork.GetRepository<Genre>();

            if (genreRepo.Exists(g => g.Name.ToLower() == expectedEntityValues.Name.ToLower()))
                throw new Exception($"Genre named {expectedEntityValues.Name} is already exists in database.");

            var genreModel = _mapper.Map<Genre>(expectedEntityValues);

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
