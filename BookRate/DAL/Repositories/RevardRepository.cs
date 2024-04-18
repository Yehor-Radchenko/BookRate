using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.DAL.Repositories
{
    public class RevardRepository : IRevardRepository
    {
        private readonly BookRateDbContext _context;
        public RevardRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Revard entity)
        {
            _context.Revards.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Revard entity)
        {
            _context.Revards.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Revard>> GetAllAsync()
        {
            return await _context.Revards.ToListAsync();
        }

        public async Task<Revard?> GetByIdAsync(int id)
        {
            return await _context.Revards.FindAsync(id);
        }

        public async Task<bool> Update(Revard entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool IsAnyNarrativeRevardReferenced(int revardId)
        {
            return _context.Revards.Any(r => r.Id == revardId && r.NarrativeRevards.Any());
        }

        public bool IsRevardWithNameExists(string name)
        {
            return _context.Revards.Any(r => name.ToLower() == r.Name.ToLower());
        }
    }
}
