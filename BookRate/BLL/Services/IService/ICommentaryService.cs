using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services.IService
{
    public interface ICommentaryService
    {
        Task<bool> Add(CreateCommentaryDTO dto);
        Task<bool> Update(UpdateCommentaryDTO expectedEntityValues);
        Task<bool> Delete(int id);
        Task<IEnumerable<CommentaryViewModel>> GetAll();
        Task<CommentaryViewModel?> GetById(int? id);
    }
}
