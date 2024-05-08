using BookRate.BLL.ViewModels.Role;
using BookRate.DAL.DTO;
using BookRate.DAL.DTO.Role;

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
