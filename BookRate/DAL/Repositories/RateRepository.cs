using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookRate.DAL.Repositories
{
    public class RateRepository : IRateRepository
    {
        private readonly BookRateDbContext _context;
        public RateRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Rate entity)
        {
            _context.Rates.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Rate entity)
        {
            _context.Rates.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Rate>> GetAllAsync()
        {
            return await _context.Rates.ToListAsync();
        }

        public async Task<Rate?> GetByIdAsync(int id)
        {
            return await _context.Rates.FindAsync(id);
        }

        public async Task<bool> Update(Rate entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
