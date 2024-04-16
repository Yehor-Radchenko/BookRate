using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<bool> Add(CreateRoleDTO roleDTO)
        {
            if (_roleRepository.IsRoleWithNameExists(roleDTO.Name))
                throw new Exception($"Role named {roleDTO.Name} is already exists in database.");

            try
            {
                Role role = new Role
                {
                    Name = roleDTO.Name,
                };

                await _roleRepository.Add(role);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            if (_roleRepository.IsAnyCotributorReferenced(id))
                throw new Exception("Role cant be removed because it referenced by at least one contributor.");

            try
            {
                await _roleRepository.Delete(new Role { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<RoleViewModel>> GetAll()
        {
            try
            {
                IEnumerable<Role> roleModels = await _roleRepository.GetAllAsync();
                List<RoleViewModel> roleViewModels = new List<RoleViewModel>();

                foreach (var model in roleModels)
                {
                    RoleViewModel vm = new RoleViewModel
                    {
                        Id = model.Id,
                        Name = model.Name,
                    };

                    roleViewModels.Add(vm);
                }

                return roleViewModels;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw new Exception("An error occurred while retrieving roles.", ex);
            }
        }


        public async Task<RoleViewModel?> GetById(int? id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Id is null.");

                Role? roleModel = await _roleRepository.GetByIdAsync(id.Value);

                if (roleModel == null)
                    throw new Exception($"There is no model with Id {id}");

                return new RoleViewModel
                {
                    Id = roleModel.Id,
                    Name = roleModel.Name,
                };
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw new Exception("An error occurred while retrieving the role.", ex);
            }
        }

        public async Task<bool> Update(UpdateRoleDTO expectedEntityValues)
        {
            if (_roleRepository.IsRoleWithNameExists(expectedEntityValues.Name))
                throw new Exception($"Role named {expectedEntityValues.Name} is already exists in database.");

            try
            {
                Role roleModel = new Role
                {
                    Id = expectedEntityValues.Id,
                    Name = expectedEntityValues.Name,
                };

                await _roleRepository.Update(roleModel);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the role.", ex);
            }
        }
    }
}
