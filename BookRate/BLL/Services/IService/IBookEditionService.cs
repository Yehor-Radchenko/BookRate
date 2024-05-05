using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services.IService
{
    public interface IBookEditionService
    {
        Task<bool> Add(CreateBookEditionDTO dto);
        Task<bool> Update(UpdateBookEditionDTO expectedEntityValues);
        Task<bool> Delete(int id);
        Task<IEnumerable<BookEditionViewModel>> GetAll();
        Task<BookEditionViewModel?> GetById(int? id);
    }
}
