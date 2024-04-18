using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.DAL.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly BookRateDbContext _context;
        public ReviewRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Review entity)
        {
            _context.Reviews.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Review entity)
        {
            _context.Reviews.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public async Task<bool> Update(Review entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool IsAnyCommentaryReferenced(int reviewId)
        {
            return _context.Reviews.Any(r => r.Id == reviewId && r.Commentaries.Any());
        }

        public bool IsAnyReviewLikeReferenced(int reviewId)
        {
            return _context.Reviews.Any(r => r.Id == reviewId && r.ReviewLikes.Any());
        }

        public bool IsReviewWithTitleExists(string title)
        {
            return _context.Reviews.Any(r => title.ToLower() == r.Title.ToLower());
        }
    }
}
