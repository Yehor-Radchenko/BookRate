using BookRate.BLL.ViewModels.Narrative;
using BookRate.DAL.DTO;
using BookRate.DAL.DTO.Narrative;

namespace BookRate.BLL.Services.IService
{
    public interface INarrativeService
    {
        Task<bool> Add(CreateNarrativeDTO dto);
        Task<bool> Update(UpdateNarrativeDTO expectedEntityValues);
        Task<bool> Delete(int id);
        Task<IEnumerable<NarrativeViewModel>> GetAll();
        Task<NarrativeViewModel?> GetById(int? id);
    }
}
