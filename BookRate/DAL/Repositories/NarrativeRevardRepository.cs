using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.DAL.Repositories
{
    public class NarrativeRevardRepository : INarrativeRevardRepository
    {
        private readonly BookRateDbContext _context;
        public NarrativeRevardRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(NarrativeRevard entity)
        {
            _context.NarrativeRevards.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(NarrativeRevard entity)
        {
            _context.NarrativeRevards.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<NarrativeRevard>> GetAllAsync()
        {
            return await _context.NarrativeRevards.ToListAsync();
        }

        public async Task<NarrativeRevard?> GetByIdAsync(int id)
        {
            return await _context.NarrativeRevards.FindAsync(id);
        }

        public async Task<bool> Update(NarrativeRevard entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
