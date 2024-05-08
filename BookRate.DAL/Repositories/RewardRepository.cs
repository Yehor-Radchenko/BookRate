using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookRate.DAL.Repositories
{
    public class RewardRepository : IRewardRepository
    {
        private readonly BookRateDbContext _context;
        public RewardRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Reward entity)
        {
            _context.Rewards.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Reward entity)
        {
            _context.Rewards.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Reward>> GetAllAsync()
        {
            return await _context.Rewards.ToListAsync();
        }

        public async Task<Reward?> GetByIdAsync(int id)
        {
            return await _context.Rewards.FindAsync(id);
        }

        public async Task<bool> Update(Reward entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool IsAnyNarrativeRewardReferenced(int revardId)
        {
            return _context.Rewards.Any(r => r.Id == revardId && r.NarrativeRewards.Any());
        }
    }
}
