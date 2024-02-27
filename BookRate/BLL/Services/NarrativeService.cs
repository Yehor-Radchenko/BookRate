using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;

namespace BookRate.BLL.Services
{
    public class NarrativeService : INarrativeService
    {
        private readonly Repository<Narrative> _narrativeRepository;
        private readonly IMapper _mapper;

        public NarrativeService(Repository<Narrative> narrativeRepository, IMapper mapper)
        {
            _narrativeRepository = narrativeRepository;
            _mapper = mapper;
        }

        public Task<bool> Create(NarrativeDTO model)
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

        public Task<bool> Update(NarrativeDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
