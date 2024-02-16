using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services.IService
{
    public interface IUserService : IService<UserDTO, UserViewModel>
    {
    }
}
