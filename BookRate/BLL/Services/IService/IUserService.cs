using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services.IService
{
    public interface IUserService
    {
        Task<bool> Add(CreateUserDTO dto);
        Task<bool> Update(UpdateUserDTO expectedEntityValues);
        Task<bool> Delete(int id);
        Task<IEnumerable<UserViewModel>> GetAll();
        Task<UserViewModel?> GetById(int? id);
    }
}
