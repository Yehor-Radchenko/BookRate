using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookRate.DAL.Repositories
{
    public class ContributorRepository : IContributorRepository
    {
        private readonly BookRateDbContext _context;

        public ContributorRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Contributor entity)
        {
            _context.Contributors.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Contributor entity)
        {
            _context.Contributors.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Contributor>> GetAllAsync()
        {
            return await _context.Contributors.ToListAsync();
        }

        public async Task<Contributor?> GetByIdAsync(int id)
        {
            return await _context.Contributors.FindAsync(id);
        }

        public async Task<bool> Update(Contributor entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool IsAnyNarrativeReferenced(int contributorId)
        {
            return _context.Contributors.Any(c => c.Id == contributorId && c.Narratives.Any());
        }

        public bool IsAnyRoleReferenced(int contributorId)
        {
            return _context.Contributors.Any(c => c.Id == contributorId && c.Roles.Any());
        }

        public bool IsContributorWithNameExists(string firstName, string lastName)
        {
            return _context.Contributors.Any(c => c.FirstName.ToLower() == firstName.ToLower() && c.LastName
            .ToLower() == lastName.ToLower()); 
        }
    }
}
