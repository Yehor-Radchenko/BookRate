using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services
{
    public class RoleService : IRoleService
    {
        public Task<bool> Create(RoleDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoleViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<RoleViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(RoleDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
