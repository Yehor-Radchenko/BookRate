using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookRate.DAL.Repositories
{
    public class CommentaryLikeRepository : ICommentaryLikeRepository
    {
        private readonly BookRateDbContext _context;

        public CommentaryLikeRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(CommentaryLike entity)
        {
            _context.CommentaryLikes.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(CommentaryLike entity)
        {
            _context.CommentaryLikes.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CommentaryLike>> GetAllAsync()
        {
            return await _context.CommentaryLikes.ToListAsync();
        }

        public async Task<CommentaryLike?> GetByIdAsync(int id)
        {
            return await _context.CommentaryLikes.FindAsync(id);
        }


    }
}
