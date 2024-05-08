using BookRate.DAL.Models;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface IRoleRepository : IRepository<Role>
    {
        bool IsAnyContributorReferenced(int roleId);
        bool IsRoleWithNameExists(string name);
    }
}
