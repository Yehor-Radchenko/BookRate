using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;

namespace BookRate.BLL.Services
{
    public class NarrativeService : INarrativeService
    {
        private readonly BookRateDbContext _context;
        private readonly IMapper _mapper;

        public NarrativeService(BookRateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> Create(UpdateNarrativeDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NarrativeViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<NarrativeViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UpdateNarrativeDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
