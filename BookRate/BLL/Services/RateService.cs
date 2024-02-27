using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;

namespace BookRate.BLL.Services
{
    public class RateService : IRateService
    {
        private readonly Repository<Rate> _rateRepository;
        private readonly IMapper _mapper;

        public RateService(Repository<Rate> rateRepository, IMapper mapper)
        {
            _rateRepository = rateRepository;
            _mapper = mapper;
        }

        public Task<bool> Create(RateDTO model)
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

        public Task<bool> Update(RateDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
