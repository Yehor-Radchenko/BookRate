using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookRate.DAL.Repositories
{
    public class CommentaryRepository : ICommentaryRepository
    {
        private readonly BookRateDbContext _context;

        public CommentaryRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Commentary entity)
        {
            _context.Commentaries.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Commentary entity)
        {
            _context.Commentaries.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Commentary>> GetAllAsync()
        {
            return await _context.Commentaries.ToListAsync();
        }

        public async Task<Commentary?> GetByIdAsync(int id)
        {
            return await _context.Commentaries.FindAsync(id);
        }

        public async Task<bool> Update(Commentary entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
        public bool IsAnyCommentaryLikeReferenced(int commentaryId)
        {
            return _context.Commentaries.Any(c => c.Id == commentaryId && c.CommentaryLikes.Any());
        }
    }
}
