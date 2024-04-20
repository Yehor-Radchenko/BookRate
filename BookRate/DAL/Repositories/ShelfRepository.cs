using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.DAL.Repositories
{
    public class ShelfRepository : IShelfRepository
    {
        private readonly BookRateDbContext _context;

        public ShelfRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Shelf entity)
        {
            _context.Shelves.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Shelf entity)
        {
            _context.Shelves.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Shelf>> GetAllAsync()
        {
            return await _context.Shelves.ToListAsync();
        }

        public async Task<Shelf?> GetByIdAsync(int id)
        {
            return await _context.Shelves.FindAsync(id);
        }

        public async Task<bool> Update(Shelf entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool IsShelfWithNameExists(string name)
        {
            return _context.Shelves.Any(s => name.ToLower() == s.Name.ToLower());
        }
    }
}
