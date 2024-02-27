using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;

namespace BookRate.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly Repository<Role> _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(Repository<Role> roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

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
