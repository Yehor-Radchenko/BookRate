using BookRate.DAL.Models;

namespace BookRate.DAL.Repositories.IRepository
{
    public interface IEditionRepository : IRepository<Edition>
    {
        bool IsAnyBookEditionReferenced(int editionId);
        bool IsEditionWithNameExists(string name);
    }
}
