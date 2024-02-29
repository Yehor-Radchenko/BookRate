using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services
{
    public class EditionService : IEditionService
    {
        private readonly BookRateDbContext _context;
        private readonly IMapper _mapper;

        public EditionService(BookRateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> Create(EditionDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EditionViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<EditionViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(EditionDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
