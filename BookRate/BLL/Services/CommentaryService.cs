using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services
{
    public class CommentaryService : ICommentaryService
    {
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
