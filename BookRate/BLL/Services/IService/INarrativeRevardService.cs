using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services.IService
{
    public interface INarrativeRevardService
    {
        Task<bool> Add(CreateNarrativeRevardDTO dto);
        Task<bool> Update(UpdateNarrativeDTO expectedEntityValues);
        Task<bool> Delete(int id);
        Task<IEnumerable<NarrativeRevardViewModel>> GetAll();
        Task<NarrativeRevardViewModel?> GetById(int? id);
    }
}
