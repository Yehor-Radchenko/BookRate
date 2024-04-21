using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;

namespace BookRate.BLL.Services
{
    public class RevardService : IRevardService
    {
        private readonly BookRateDbContext _context;
        private readonly IMapper _mapper;

        public RevardService(BookRateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> Create(UpdateRevardDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RevardViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<RevardViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UpdateRevardDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
