using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;

namespace BookRate.BLL.Services
{
    public class SerieService : ISerieService
    {
        private readonly Repository<Serie> _serieRepository;
        private readonly IMapper _mapper;

        public SerieService(Repository<Serie> serieRepository, IMapper mapper)
        {
            _serieRepository = serieRepository;
            _mapper = mapper;
        }

        public Task<bool> Create(SerieDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SerieViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SerieViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(SerieDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
