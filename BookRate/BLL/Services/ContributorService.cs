using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;

namespace BookRate.BLL.Services
{
    public class ContributorService : IContributorService
    {
        private readonly Repository<Contributor> _contributorRepository;
        private readonly IMapper _mapper;

        public ContributorService(Repository<Contributor> contributorRepository, IMapper mapper)
        {
            _contributorRepository = contributorRepository;
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
