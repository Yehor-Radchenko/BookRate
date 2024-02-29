using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services
{
    public class GenreService : IGenreService
    {
        private readonly BookRateDbContext _context;
        private readonly IMapper _mapper;

        public GenreService(BookRateDbContext context, IMapper mapper)
        {
            _context = context;
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
