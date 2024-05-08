using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookRate.DAL.Repositories
{
    public class BookEditionRepository : IBookEditionRepository
    {
        private readonly BookRateDbContext _context;

        public BookEditionRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(BookEdition entity)
        {
            _context.BookEditions.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(BookEdition entity)
        {
            _context.BookEditions.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BookEdition>> GetAllAsync()
        {
            return await _context.BookEditions.ToListAsync();
        }

        public async Task<BookEdition?> GetByIdAsync(int id)
        {
            return await _context.BookEditions.FindAsync(id);
        }

        public async Task<bool> Update(BookEdition entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
