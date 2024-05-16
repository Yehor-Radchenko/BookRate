using AutoMapper;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.Genre;
using BookRate.BLL.ViewModels.Role;
using BookRate.DAL.DTO.Role;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.BLL.Services
{
    public class RoleService : BaseService, IService<CreateRoleDTO, UpdateRoleDTO, Role>
    {
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> AddAsync(CreateRoleDTO dto)
        {
            var roleRepo = _unitOfWork.GetRepository<Role>();

            if (roleRepo.Exists(g => g.Name.ToLower() == dto.Name.ToLower()))
                throw new Exception($"Role named {dto.Name} is already exists in database.");

            var roleModel = _mapper.Map<Role>(dto);

            await roleRepo.AddAsync(roleModel);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var roleRepo = _unitOfWork.GetRepository<Role>();

            if (roleRepo.Exists(g => g.Id == id && g.Contributors.Any()))
                throw new Exception("Role cant be removed because it referenced by at least one narrative.");

            if (roleRepo.Exists(g => g.Id == id && g.Contributors.Any()))
                throw new Exception("Role cant be removed because it referenced by at least one contributor.");

            await roleRepo.Delete(new Role { Id = id });
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(UpdateRoleDTO expectedEntityValues)
        {
            var roleRepo = _unitOfWork.GetRepository<Role>();

            if (roleRepo.Exists(g => g.Name.ToLower() == expectedEntityValues.Name.ToLower()))
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

        public async Task<IEnumerable<RoleViewModel>> GetRoleListModelsAsync()
        {
            var roleRepository = _unitOfWork.GetRepository<Role>();

            var list = await roleRepository.GetAllAsync();

            var getMappedList = _mapper.Map<IEnumerable<RoleViewModel>>(list);

            return getMappedList;
        }
    }
}

