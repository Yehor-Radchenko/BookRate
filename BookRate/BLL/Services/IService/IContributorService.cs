using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services.IService
{
    public interface IContributorService
    {
        Task<bool> Add(CreateContributorDTO genreDTO);
        Task<bool> Update(UpdateContributorDTO expectedEntityValues);
        Task<bool> Delete(int id);
        Task<IEnumerable<ContributorViewModel>> GetAll();
        Task<ContributorViewModel?> GetById(int? id);
    }
}
