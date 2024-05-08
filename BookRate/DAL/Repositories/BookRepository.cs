using BookRate.BLL.ViewModels;
using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookRate.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookRateDbContext _context;

        public BookRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Book entity)
        {
            try
            {
                _context.Books.Add(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            } catch (Exception ex) { return -1;}
        }

        public async Task<bool> Delete(Book entity)
        {
            _context.Books.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<bool> Update(Book entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool IsAnyNarrativeReferenced(int bookId)
        {
            return _context.Books.Any(b => b.Id == bookId && b.Narratives.Any());
        }

        public bool IsAnyRateReferenced(int bookId)
        {
            return _context.Books.Any(b => b.Id == bookId && b.Rates.Any());
        }

        public bool IsAnyBookEditionReferenced(int bookId)
        {
            return _context.Books.Any(b => b.Id == bookId && b.BookEditions.Any());
        }

        public bool IsAnyReviewReferenced(int bookId)
        {
            return _context.Books.Any(b => b.Id == bookId && b.Reviews.Any());
        }

        public bool IsAnyShelfReferenced(int bookId)
        {
            return _context.Books.Any(b => b.Id == bookId && b.Shelves.Any());
        }

        public async Task<List<Book>> GetTopOfWeekBooks()
        {
            DateTime lastWeekStart = DateTime.Today.AddDays(-7);
            DateTime lastWeekEnd = DateTime.Today;

            var topBookIds = await _context.Rates
                .Where(r => r.DateRated >= lastWeekStart && r.DateRated <= lastWeekEnd)
                .Select(r => r.BookId)
                .Distinct()
                .ToListAsync();

            return await _context.Books
                .Include(b => b.Narratives)
                    .ThenInclude(n => n.Contributors)
                        .ThenInclude(c => c.Roles)
                .Include(b => b.BookEditions)
                .Where(b => topBookIds.Contains(b.Id))
                .ToListAsync();
        }

        public async Task<BookEdition?> GetSpecificBookInfoAsync(int bookEditionId)
        {
            return await _context.BookEditions
                .Include(be => be.Book)
                .ThenInclude(b => b.Narratives)
                .FirstAsync(be => be.Id == bookEditionId);
        }
    }
}
