using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services
{
    public class ContributorService : IContributorService
    {
        private readonly BookRateDbContext _context;
        private readonly IMapper _mapper;

        public ContributorService(BookRateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> Create(ContributorDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContributorViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ContributorViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ContributorDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
