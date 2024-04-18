using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookRate.DAL.Repositories
{
    public class SettingRepository : ISettingRepository
    {
        private readonly BookRateDbContext _context;

        public SettingRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Setting entity)
        {
            _context.Settings.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Setting entity)
        {
            _context.Settings.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Setting>> GetAllAsync()
        {
            return await _context.Settings.ToListAsync();
        }

        public async Task<Setting?> GetByIdAsync(int id)
        {
            return await _context.Settings.FindAsync(id);
        }

        public async Task<bool> Update(Setting entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool IsAnyNarrativeReferenced(int settingId)
        {
            return _context.Settings.Any(s => s.Id == settingId && s.Narratives.Any());
        }

        public bool IsSettingWithNameExists(string name)
        {
            return _context.Settings.Any(s => name.ToLower() == s.Name.ToLower());
        }
    }
}
