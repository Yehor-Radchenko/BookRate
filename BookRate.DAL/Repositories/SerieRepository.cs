using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookRate.DAL.Repositories
{
    public class SerieRepository : ISerieRepository
    {
        private readonly BookRateDbContext _context;

        public SerieRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Serie entity)
        {
            _context.Series.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Serie entity)
        {
            _context.Series.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Serie>> GetAllAsync()
        {
            return await _context.Series.ToListAsync();
        }

        public async Task<Serie?> GetByIdAsync(int id)
        {
            return await _context.Series.FindAsync(id);
        }

        public async Task<bool> Update(Serie entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool IsAnyBookReferenced(int serieId)
        {
            return _context.Series.Any(s => s.Id == serieId && s.Books.Any());
        }


        public bool IsSerieWithNameExists(string name)
        {
            return _context.Series.Any(s => name.ToLower() == s.Name.ToLower());
        }
    }
}
