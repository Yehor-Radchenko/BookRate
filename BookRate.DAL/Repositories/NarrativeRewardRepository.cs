using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookRate.DAL.Repositories
{
    public class NarrativeRewardRepository : INarrativeRewardRepository
    {
        private readonly BookRateDbContext _context;
        public NarrativeRewardRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(NarrativeReward entity)
        {
            _context.NarrativeRewards.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(NarrativeReward entity)
        {
            _context.NarrativeRewards.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<NarrativeReward>> GetAllAsync()
        {
            return await _context.NarrativeRewards.ToListAsync();
        }

        public async Task<NarrativeReward?> GetByIdAsync(int id)
        {
            return await _context.NarrativeRewards.FindAsync(id);
        }

        public async Task<bool> Update(NarrativeReward entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
