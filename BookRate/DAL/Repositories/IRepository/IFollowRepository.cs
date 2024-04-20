using BookRate.DAL.Models;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface IFollowRepository
    {
        Task<Follow?> GetByIdAsync(int id);
        Task<IEnumerable<Follow>> GetAllAsync();
        Task<bool> Add(Follow entity);
        Task<bool> Delete(Follow entity);
    }
}
