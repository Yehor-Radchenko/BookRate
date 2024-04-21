using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services
{
    public class CommentaryService : ICommentaryService
    {
        private readonly BookRateDbContext _context;
        private readonly IMapper _mapper;
        public CommentaryService(BookRateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> Create(CreateCommentaryDTO model)
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

        public Task<bool> Update(CreateCommentaryDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
