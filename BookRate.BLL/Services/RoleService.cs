using AutoMapper;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.Genre;
using BookRate.BLL.ViewModels.Role;
using BookRate.DAL.DTO.Reward;
using BookRate.DAL.DTO.Role;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
using FluentValidation;
using FluentValidation.Results;

namespace BookRate.BLL.Services
{
    public class RoleService : BaseService<Role, RoleDto>, IService<RoleDto>
    {
        public RoleService(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IValidator<RoleDto> validator
            ) : base(unitOfWork, mapper, validator)
        {
        }

        public async Task<int> AddAsync(RoleDto dto)
        {
            ValidationResult result = await _validator.ValidateAsync(dto);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var roleRepo = _unitOfWork.GetRepository<Role>();

            if (roleRepo.Exists(r => r.Name.Trim().ToLower() == dto.Name.Trim().ToLower()))
                throw new Exception($"Role named {dto.Name} is already exists in database.");

            var roleModel = _mapper.Map<Role>(dto);

            await roleRepo.AddAsync(roleModel);
            await _unitOfWork.CommitAsync();
            return roleModel.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var roleRepo = _unitOfWork.GetRepository<Role>();

            Role? roleToDelete = await roleRepo.GetAsync(g => g.Id == id);

            if (roleToDelete is null)
                throw new ArgumentException($"There is no model with Id {id}", nameof(id));

            await roleRepo.Delete(roleToDelete);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, RoleDto expectedEntityValues)
        {
            ValidationResult result = await _validator.ValidateAsync(expectedEntityValues);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

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

