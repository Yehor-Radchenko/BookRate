using BookRate.DAL.Models;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface IBookRepository : IRepository<Book>
    {
        bool IsAnyBookEditionReferenced(int bookId);
        bool IsAnyRateReferenced(int bookId);
        bool IsAnyReviewReferenced(int bookId);
        bool IsAnyNarrativeReferenced(int bookId);
        bool IsAnyShelfReferenced(int bookId);
    }
}
