using AutoMapper;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.Genre;
using BookRate.BLL.ViewModels.Role;
using BookRate.DAL.DTO.Reward;
using BookRate.DAL.DTO.Role;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.BLL.Services
{
    public class RoleService : BaseService<Role, CreateRoleDTO, UpdateRoleDTO>
    {
        public RoleService(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IValidator<BaseRoleDTO> validator
            ) : base(unitOfWork, mapper, validator)
        {
        }

        public async override Task<int> AddAsync(CreateRoleDTO dto)
        {
            var roleRepo = _unitOfWork.GetRepository<Role>();

            if (roleRepo.Exists(r => r.Name.Trim().ToLower() == dto.Name.Trim().ToLower()))
                throw new Exception($"Role named {dto.Name} is already exists in database.");

            var roleModel = _mapper.Map<Role>(dto);

            await roleRepo.AddAsync(roleModel);
            await _unitOfWork.CommitAsync();
            return roleModel.Id;
        }

        public async override Task<bool> Delete(int id)
        {
            var roleRepo = _unitOfWork.GetRepository<Role>();

            if (roleRepo.Exists(r => r.Id == id && r.ContributorRoles.Any()))
                throw new Exception("Role cant be removed because it referenced by at least one contributor.");

            await roleRepo.Delete(new Role { Id = id });
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async override Task<bool> UpdateAsync(UpdateRoleDTO expectedEntityValues)
        {
            var roleRepo = _unitOfWork.GetRepository<Role>();

            if (roleRepo.Exists(r => r.Name.Trim().ToLower() == expectedEntityValues.Name.Trim().ToLower()))
                throw new Exception($"Role named {expectedEntityValues.Name} is already exists in database.");

            var roleModel = _mapper.Map<Role>(expectedEntityValues);

            await roleRepo.UpdateAsync(roleModel);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<RoleViewModel?> GetByIdAsync(int? id)
        {
            var roleRepo = _unitOfWork.GetRepository<Role>();

            Role? roleModel = await roleRepo.GetAsync(g => g.Id == id);

            if (roleModel is null)
                throw new Exception($"There is no model with Id {id}");

            return _mapper.Map<RoleViewModel>(roleModel);
        }

        public async Task<IEnumerable<RoleViewModel>> GetRolesAsync()
        {
            var roleRepository = _unitOfWork.GetRepository<Role>();

            var list = await roleRepository.GetAllAsync();

            var getMappedList = _mapper.Map<IEnumerable<RoleViewModel>>(list);

            return getMappedList;
        }
    }
}

