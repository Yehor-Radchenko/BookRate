using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookRate.DAL.Repositories
{
    public class FollowRepository : IFollowRepository
    {
        private readonly BookRateDbContext _context;

        public FollowRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Follow entity)
        {
            _context.Follows.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(Follow entity)
        {
            _context.Follows.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Follow>> GetAllAsync()
        {
            return await _context.Follows.ToListAsync();
        }

        public async Task<Follow?> GetByIdAsync(int id)
        {
            return await _context.Follows.FindAsync(id);
        }

        public async Task<bool> Update(Follow entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
