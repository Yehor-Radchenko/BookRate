using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;

namespace BookRate.BLL.Services
{
    public class EditionService : IEditionService
    {
        private readonly Repository<Edition> _editionRepository;
        private readonly IMapper _mapper;

        public EditionService(Repository<Edition> editionRepository, IMapper mapper)
        {
            _editionRepository = editionRepository;
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
