using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;

namespace BookRate.BLL.Services
{
    public class RateService : IRateService
    {
        private readonly BookRateDbContext _context;
        private readonly IMapper _mapper;

        public RateService(BookRateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> Create(UpdateRateDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RateViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<RateViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UpdateRateDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
