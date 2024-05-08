using BookRate.DAL.Models;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface IBookRepository
    {
        Task<Book?> GetByIdAsync(int id);
        Task<BookEdition?> GetSpecificBookInfoAsync(int bookEditionId);
        Task<int> Add(Book entity);
        Task<bool> Update(Book entity);
        Task<bool> Delete(Book entity);
        bool IsAnyBookEditionReferenced(int bookId);
        bool IsAnyRateReferenced(int bookId);
        bool IsAnyReviewReferenced(int bookId);
        bool IsAnyNarrativeReferenced(int bookId);
        bool IsAnyShelfReferenced(int bookId);
        Task<List<Book>> GetTopOfWeekBooks();
    }
}
