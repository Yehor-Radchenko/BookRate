using BookRate.BLL.ViewModels.Book;
using BookRate.DAL.DTO;
using BookRate.DAL.DTO.Book;

namespace BookRate.BLL.Services.IService
{
    public interface IBookService
    {
        Task<bool> Add(CreateBookDTO dto);
        Task<bool> Update(UpdateBookDTO expectedEntityValues);
        Task<bool> Delete(int id);
        Task<BookViewModel?> GetSpecificBookInfo(int? id);
        Task<List<BookCardViewModel>> GetTopOfWeekBookCards();
    }
}
