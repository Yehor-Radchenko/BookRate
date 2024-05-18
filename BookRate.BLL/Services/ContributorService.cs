using AutoMapper;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.Contributor;
using BookRate.BLL.ViewModels.Genre;
using BookRate.BLL.ViewModels.Role;
using BookRate.DAL.DTO.Contributor;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.BLL.Services
{
    public class ContributorService : BaseService, IService<CreateContributorDTO, UpdateContributorDTO, Contributor>
    {
        public ContributorService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> AddAsync(CreateContributorDTO dto)
        {
            if (dto.RolesId is null)
                throw new ArgumentException("Contributor must have at least one role.", nameof(dto.RolesId));

            var roleRepo = _unitOfWork.GetRepository<Role>();

            var selectedRoleModels = await roleRepo.GetAllAsync(r => dto.RolesId.Contains(r.Id));

            if (selectedRoleModels.Count() != dto.RolesId.Count())
                throw new ArgumentException("One or more specified roles do not exist.");

            var contributor = _mapper.Map<Contributor>(dto);
            
            await _unitOfWork.GetRepository<Contributor>().AddAsync(contributor);
            await _unitOfWork.CommitAsync();

            var contributorRoleRepo = _unitOfWork.GetRepository<ContributorRole>();
            foreach (var id in dto.RolesId)
            {
                await contributorRoleRepo.AddAsync(new ContributorRole { ContributorId = contributor.Id, RoleId = id });
            }
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var contributorRepo = _unitOfWork.GetRepository<Contributor>();

            var contributorExists = await contributorRepo.GetAsync(c => c.Id == id);
            if (contributorExists == null)
            {
                throw new ArgumentException($"Contributor with Id {id} does not exist.", nameof(id));
            }

            await contributorRepo.Delete(contributorExists);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(UpdateContributorDTO expectedEntityValues)
        {
            if (expectedEntityValues.RolesId == null || !expectedEntityValues.RolesId.Any())
                throw new ArgumentException("Contributor must have at least one role.", nameof(expectedEntityValues.RolesId));

            var contributorRepo = _unitOfWork.GetRepository<Contributor>();
            var roleRepo = _unitOfWork.GetRepository<Role>();
            var genreRepo = _unitOfWork.GetRepository<Genre>();

            var contributorModel = await contributorRepo.GetAll()
                .Include(c => c.ContributorRoles)
                .ThenInclude(cr => cr.Role)
                .Include(c => c.Genres)
                .FirstOrDefaultAsync(c => c.Id == expectedEntityValues.Id);

            if (contributorModel == null)
                throw new Exception($"Contributor with Id {expectedEntityValues.Id} not found.");

            contributorModel.ContributorRoles.Clear();
            contributorModel.Genres.Clear();
            await _unitOfWork.CommitAsync();

            _mapper.Map(expectedEntityValues, contributorModel);

            foreach (var roleId in expectedEntityValues.RolesId)
            {
                var role = await roleRepo.GetAsync(r => r.Id == roleId);
                if (role != null)
                {
                    contributorModel.ContributorRoles.Add(new ContributorRole
                    {
                        ContributorId = contributorModel.Id,
                        RoleId = role.Id
                    });
                }
            }

            foreach (var genreId in expectedEntityValues.GenresId)
            {
                var genre = await genreRepo.GetAsync(g => g.Id == genreId);
                if (genre != null)
                {
                    contributorModel.Genres.Add(genre);
                }
            }

            await contributorRepo.UpdateAsync(contributorModel);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<ContributorViewModel?> GetByIdAsync(int? id)
        {
            if (id == null)
                return null;

            var contributorRepo = _unitOfWork.GetRepository<Contributor>();

            var contributorModel = await contributorRepo.GetAll()
                .Include(c => c.Genres)
                .Include(c => c.ContributorRoles)
                    .ThenInclude(cr => cr.Role)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (contributorModel == null)
                return null;

            return _mapper.Map<ContributorViewModel>(contributorModel);
        }

        public async Task<IEnumerable<ContributorListModel>> GetContributorListModelsAsync()
        {
            var contributorRepo = _unitOfWork.GetRepository<Contributor>();

            var contributors = contributorRepo.GetAll()
                .Include(c => c.ContributorRoles)
                .ThenInclude(cr => cr.Role);

            var list = await _mapper.ProjectTo<ContributorListModel>(contributors).ToListAsync();

            return list;
        }
    }
}
