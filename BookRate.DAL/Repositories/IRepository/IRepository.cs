using System.Collections.Generic;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface IRepository<Model>
    {
        Task <Model?> GetByIdAsync(int id);
        Task <IEnumerable<Model>> GetAllAsync();
        Task<bool> Add(Model entity);
        Task<bool> Update(Model entity);
        Task<bool> Delete(Model entity);
    }
}
