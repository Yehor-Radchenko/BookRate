using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;

namespace BookRate.BLL.Services
{
    public class CommentaryService : ICommentaryService
    {
        private readonly Repository<Commentary> _bookRepository;
        private readonly IMapper _mapper;
        public CommentaryService(Repository<Commentary> commentaryRepository, IMapper mapper)
        {
            _bookRepository = commentaryRepository;
            _mapper = mapper;
        }

        public Task<bool> Create(CommentaryDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommentaryViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CommentaryViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(CommentaryDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
