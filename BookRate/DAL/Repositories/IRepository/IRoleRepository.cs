using BookRate.DAL.Models;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface IRoleRepository : IRepository<Role>
    {
        bool IsAnyCotributorReferenced(int roleId);
        bool IsRoleWithNameExists(string name);
    }
}
