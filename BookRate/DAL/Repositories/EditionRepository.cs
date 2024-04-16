using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.DAL.Repositories
{
    public class EditionRepository : IEditionRepository
    {
        private readonly BookRateDbContext _context;

        public EditionRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Edition entity)
        {
            _context.Editions.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(Edition entity)
        {
            _context.Editions.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Edition>> GetAllAsync()
        {
            return await _context.Editions.ToListAsync();
        }

        public async Task<Edition?> GetByIdAsync(int id)
        {
            return await _context.Editions.FindAsync(id);
        }

        public async Task<bool> Update(Edition entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool IsAnyBookEditionReferenced (int editionId)
        {
            return _context.Editions.Any(e => e.Id == editionId && e.BookEditions.Any());
        }

        public bool IsEditionWithNameExists(string name)
        {
            return _context.Editions.Any(e => e.Name.ToLower() == name.ToLower());
        }
    }
}
