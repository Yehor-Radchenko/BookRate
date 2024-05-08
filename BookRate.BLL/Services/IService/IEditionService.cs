using BookRate.BLL.ViewModels.Edition;
using BookRate.DAL.DTO;
using BookRate.DAL.DTO.Edition;

namespace BookRate.BLL.Services.IService
{
    public interface IEditionService
    {
        Task<bool> Add(CreateEditionDTO dto);
        Task<bool> Update(UpdateEditionDTO expectedEntityValues);
        Task<bool> Delete(int id);
        Task<IEnumerable<EditionViewModel>> GetAll();
        Task<EditionViewModel?> GetById(int? id);
    }
}
