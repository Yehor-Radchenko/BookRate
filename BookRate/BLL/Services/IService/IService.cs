namespace BookRate.BLL.Services.IService
{
    public interface IService <DTO, ViewModel>
    {
        Task<bool> Create(DTO model);
        Task<bool> Update(DTO expectedEntityValues);
        Task<ViewModel?> GetById(int? id);
        Task<IEnumerable<ViewModel>> GetAll();
        Task<bool> Delete(int? id);
    }
}
