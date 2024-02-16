using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services
{
    public class UserService : IUserService
    {
        public Task<bool> Create(UserDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UserDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
