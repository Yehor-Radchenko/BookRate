using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services.IService
{
    public interface IRoleService
    {
        Task<bool> Add(CreateRoleDTO roleDTO);
        Task<bool> Update(UpdateRoleDTO expectedEntityValues);
        Task<bool> Delete(int id);
        Task<IEnumerable<RoleViewModel>> GetAll();
        Task<RoleViewModel?> GetById(int? id);
    }
}
