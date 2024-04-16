using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookRate.DAL.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly BookRateDbContext _context;

        public GenreRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Genre entity)
        {
            _context.Genres.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Genre entity)
        {
            _context.Genres.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre?> GetByIdAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task<bool> Update(Genre entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool IsAnyNarrativeReferenced(int genreId)
        {
            return _context.Genres.Any(g => g.Id == genreId && g.Narratives.Any());
        }

        public bool IsAnyContributorReferenced(int genreId)
        {
            return _context.Genres.Any(g => g.Id == genreId && g.Narratives.Any());
        }

        public bool IsGenreWithNameExists(string name)
        {
            return _context.Genres.Any(g => name.ToLower() ==  g.Name.ToLower());
        }
    }
}
