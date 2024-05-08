using BookRate.BLL.ViewModels.Contributor;
using BookRate.DAL.DTO;
using BookRate.DAL.DTO.Contributor;

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
