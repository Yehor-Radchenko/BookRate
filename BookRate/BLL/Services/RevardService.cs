using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;

namespace BookRate.BLL.Services
{
    public class RevardService : IRevardService
    {
        private readonly Repository<Revard> _revardRepository;
        private readonly IMapper _mapper;

        public RevardService(Repository<Revard> revardRepository, IMapper mapper)
        {
            _revardRepository = revardRepository;
            _mapper = mapper;
        }

        public Task<bool> Create(RevardDTO model)
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

        public Task<bool> Update(RevardDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
