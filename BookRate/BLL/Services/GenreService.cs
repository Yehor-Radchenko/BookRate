using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;

namespace BookRate.BLL.Services
{
    public class GenreService : IGenreService
    {
        private readonly Repository<Genre> _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(Repository<Genre> genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public Task<bool> Create(GenreDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GenreViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<GenreViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(GenreDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
