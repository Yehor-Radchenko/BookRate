using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.DAL.Repositories
{
    public class ReviewLikeRepository : IReviewLikeRepository
    {
        private readonly BookRateDbContext _context;
        public ReviewLikeRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(ReviewLike entity)
        {
            _context.ReviewLikes.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(ReviewLike entity)
        {
            _context.ReviewLikes.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ReviewLike>> GetAllAsync()
        {
            return await _context.ReviewLikes.ToListAsync();
        }

        public async Task<ReviewLike?> GetByIdAsync(int id)
        {
            return await _context.ReviewLikes.FindAsync(id);
        }

        public async Task<bool> Update(ReviewLike entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
