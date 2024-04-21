using BookRate.BLL.ViewModels;

namespace BookRate.BLL.Services.IService
{
    public interface INarrativeRevardService
    {
        Task<bool> Add(CreateNarrativeRevardDTO dto);
        Task<bool> Update(UpdateNarrativeDTO expectedEntityValues);
        Task<bool> Delete(int id);
        Task<IEnumerable<NarrativeViewModel>> GetAll();
        Task<NarrativeViewModel?> GetById(int? id);
    }
}
