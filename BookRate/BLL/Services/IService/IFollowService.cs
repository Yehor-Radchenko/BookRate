using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

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
