using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels.Commentary;
using BookRate.DAL.DTO.Commentary;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.BLL.Services
{
    public class CommentaryService : ICommentaryService
    {
        private readonly ICommentaryRepository _commentaryRepository;
        private readonly IMapper _mapper;
        public CommentaryService(ICommentaryRepository commentaryRepository, IMapper mapper)
        {
            _commentaryRepository = commentaryRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<CommentaryViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CommentaryViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Add(CreateCommentaryDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UpdateCommentaryDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
