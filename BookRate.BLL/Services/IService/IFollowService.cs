using BookRate.BLL.ViewModels.Serie;
using BookRate.DAL.DTO;
using BookRate.DAL.DTO.Serie;

namespace BookRate.BLL.Services.IService
{
    public interface IFollowService
    {
        Task<bool> Add(CreateSerieDTO dto);
        Task<bool> Delete(int id);
        Task<IEnumerable<SerieViewModel>> GetAll();
        Task<SerieViewModel?> GetById(int? id);
    }
}
