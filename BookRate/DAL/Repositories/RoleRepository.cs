using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookRate.DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly BookRateDbContext _context;
        public RoleRepository(BookRateDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Role entity)
        {
            _context.Roles.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Role entity)
        {
            _context.Roles.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<bool> Update(Role entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool IsAnyCotributorReferenced(int roleId)
        {
            return _context.Roles.Any(r => r.Id == roleId && r.Contributors.Any());
        }

        public bool IsRoleWithNameExists(string name)
        {
            return _context.Roles.Any(g => name.ToLower() == g.Name.ToLower());
        }
    }
}
