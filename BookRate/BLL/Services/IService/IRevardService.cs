using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services.IService
{
    public interface IRevardService
    {
        Task<bool> Add(CreateRevardDTO dto);
        Task<bool> Update(UpdateRevardDTO expectedEntityValues);
        Task<bool> Delete(int id);
        Task<IEnumerable<RevardViewModel>> GetAll();
        Task<RevardViewModel?> GetById(int? id);
    }
}
