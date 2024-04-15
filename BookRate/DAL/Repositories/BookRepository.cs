using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookRateDbContext _context;

        public BookRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Book entity)
        {
            _context.Books.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Book entity)
        {
            _context.Books.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
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
            return context.Books.Any(b => b.Id == bookId && b.BookEditions.Any());
        }
        public bool IsAnyReviewReferenced(int bookId)
        {
            return context.Books.Any(b => b.Id == bookId && b.Reviews.Any());
        }
        public bool IsAnyShelfReferenced(int bookId)
        {
            return context.Books.Any(b => b.Id == bookId && b.Shelves.Any());
        }
    }
}
