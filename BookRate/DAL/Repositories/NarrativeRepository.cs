using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookRate.DAL.Repositories
{
    public class NarrativeRepository : INarrativeRepository
    {
        private readonly BookRateDbContext _context;
        public NarrativeRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Narrative entity)
        {
            _context.Narratives.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Narrative entity)
        {
            _context.Narratives.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Narrative>> GetAllAsync()
        {
            return await _context.Narratives.ToListAsync();
        }

        public async Task<Narrative?> GetByIdAsync(int id)
        {
            return await _context.Narratives.FindAsync(id);
        }

        public async Task<bool> Update(Narrative entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool IsAnyBookReferenced(int narrativeId) {
            return _context.Narratives.Any(n => n.Id == narrativeId && n.Books.Any());
        }

        public bool IsAnyNarrativeRewardReferenced(int narrativeId) {
            return _context.Narratives.Any(n => n.Id == narrativeId && n.NarrativeRewards.Any());
        }

        public bool IsAnyContributorReferenced(int narrativeId) {
            return _context.Narratives.Any(n => n.Id == narrativeId && n.Contributors.Any());
        }

        public bool IsAnyGenreReferenced(int narrativeId) {
            return _context.Narratives.Any(n => n.Id == narrativeId && n.Genres.Any());
        }

        public bool IsAnySettingReferenced(int narrativeId) {
            return _context.Narratives.Any(n => n.Id == narrativeId && n.Settings.Any());
        }
    }
}
