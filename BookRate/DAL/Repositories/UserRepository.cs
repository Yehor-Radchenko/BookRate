using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookRate.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BookRateDbContext _context;

        public UserRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(User entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(User entity)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool IsAnyCommentaryReferenced(int userId)
        {
            return _context.Users.Any(u => u.Id == userId && u.Commentaries.Any());
        }

        public bool IsAnyRateReferenced(int userId)
        {
            return _context.Users.Any(u => u.Id == userId && u.Rates.Any());
        }

        public bool IsAnyCommentaryLikeReferenced(int userId)
        {
            return _context.Users.Any(u => u.Id == userId && u.CommentaryLikes.Any());
        }

        public bool IsAnyReviewReferenced(int userId)
        {
            return _context.Users.Any(u => u.Id == userId && u.Reviews.Any());
        }

        public bool IsAnyReviewLikeReferenced(int userId)
        {
            return _context.Users.Any(u => u.Id == userId && u.ReviewLikes.Any());
        }

        public bool IsUserWithEmailExists(string email)
        {
            return _context.Users.Any(u => email.ToLower() == u.Email.ToLower());
        }
    }
}
