using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;

namespace BookRate.BLL.Services
{
    public class SerieService : ISerieService
    {
        private readonly BookRateDbContext _context;
        private readonly IMapper _mapper;

        public SerieService(BookRateDbContext context, IMapper mapper)
        {
            _context = context;
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
