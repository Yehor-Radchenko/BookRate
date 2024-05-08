using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;
using BookRate.DAL.Repositories.IRepository;
using System.Data;

namespace BookRate.BLL.Services
{
    public class ContributorService : IContributorService
    {
        private readonly IContributorRepository _contributorRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public ContributorService(IContributorRepository contributorRepository, IRoleRepository roleRepository, IMapper mapper)
        {
            _contributorRepository = contributorRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<bool> Add(CreateContributorDTO dto)
        {
            if(dto.RolesId is null)
                throw new Exception($"Contributor without at least one role can't be created.");

            List<Role> selectedRoleModels = new List<Role>();
            foreach (int roleId in dto.RolesId)
            {
                var roleModel = await _roleRepository.GetByIdAsync(roleId);
                if (roleModel is not null)
                    selectedRoleModels.Add(roleModel);
                else
                    throw new Exception($"Role with specified Id: {roleId} not found.");
            }

            try
            {
                var contributor = _mapper.Map<Contributor>(dto);
                contributor.Roles = selectedRoleModels.ToList();
                await _contributorRepository.Add(contributor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            if (_contributorRepository.IsAnyNarrativeReferenced(id))
                throw new Exception("Contributor can't be removed because it referenced by at least one narrative.");

            try
            {
                await _contributorRepository.Delete(new Contributor { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ContributorViewModel>> GetAll()
        {
            try
            {
                IEnumerable<Contributor> contributorModels = await _contributorRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<ContributorViewModel>>(contributorModels);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving contributors.", ex);
            }
        }

        public async Task<ContributorViewModel?> GetById(int? id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Id is null.");

                Contributor? contributorModel = await _contributorRepository.GetByIdAsync(id.Value);

                if (contributorModel == null)
                    throw new Exception($"There is no contributor with Id {id}");

                return _mapper.Map<ContributorViewModel>(contributorModel);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving contributor.", ex);
            }
        }

        public async Task<bool> Update(UpdateContributorDTO expectedEntityValues)
        {
            try
            {
                var contributorModel = _mapper.Map<Contributor>(expectedEntityValues);

                await _contributorRepository.Update(contributorModel);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating contributor.", ex);
            }
        }
    }
}
