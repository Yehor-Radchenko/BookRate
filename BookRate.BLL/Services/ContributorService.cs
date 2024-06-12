using AutoMapper;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.Contributor;
using BookRate.DAL.DTO.Contributor;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using System.Linq;

namespace BookRate.BLL.Services
{
    public class ContributorService : BaseService<Contributor, ContributorDto>, IService<ContributorDto>
    {
        public ContributorService(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IValidator<ContributorDto> validator
            ) : base(unitOfWork, mapper, validator)
        { 
        }

        public async Task<int> AddAsync(ContributorDto dto)
        {
            ValidationResult result = await _validator.ValidateAsync(dto);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);   

            var roleRepo = _unitOfWork.GetRepository<Role>();
            var genreRepo = _unitOfWork.GetRepository<Genre>();

            var selectedRoleModels = await roleRepo.GetAllAsync(r => dto.RolesId.Contains(r.Id));
            var selectedGenreModels = dto.GenresId != null ? await genreRepo.GetAllAsync(g => dto.GenresId.Contains(g.Id)) : new List<Genre>();

            if (selectedRoleModels.Count() != dto.RolesId.Count())
                throw new ArgumentException("One or more specified roles do not exist.");

            if (dto.GenresId != null && selectedGenreModels.Count() != dto.GenresId.Count())
                throw new ArgumentException("One or more specified genres do not exist.");

            var contributor = _mapper.Map<Contributor>(dto);

            contributor.Genres = selectedGenreModels.ToList();

            foreach (var role in selectedRoleModels)
            {
                contributor.ContributorRoles.Add(new ContributorRole { RoleId = role.Id, ContributorId = contributor.Id });
            }

            if(dto.Photo is not null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await dto.Photo.CopyToAsync(memoryStream);
                    contributor.Photo = new Photo { Data = memoryStream.ToArray() };
                }
            }

            await _unitOfWork.GetRepository<Contributor>().AddAsync(contributor);
            await _unitOfWork.CommitAsync();
            return contributor.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var contributorRepo = _unitOfWork.GetRepository<Contributor>();

            var contributor = await contributorRepo.GetAsync(c => c.Id == id, "ContributorRoles.NarrativeContributorRoles");
            if (contributor is null)
                throw new ArgumentException($"Contributor with Id {id} does not exist.", nameof(id));

            if (contributor.ContributorRoles.Any(cr => cr.NarrativeContributorRoles.Any()))
                throw new InvalidOperationException("Cannot delete contributor with associated narrative roles.");

            await contributorRepo.Delete(contributor);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, ContributorDto expectedEntityValues)
        {
            ValidationResult result = await _validator.ValidateAsync(expectedEntityValues);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var contributorRepo = _unitOfWork.GetRepository<Contributor>();
            var contributorRoleRepo = _unitOfWork.GetRepository<ContributorRole>();
            var roleRepo = _unitOfWork.GetRepository<Role>();
            var genreRepo = _unitOfWork.GetRepository<Genre>();
            var photoRepo = _unitOfWork.GetRepository<Photo>();

            var contributorModel = await contributorRepo.GetAsync(c => c.Id == id, "Genres,ContributorRoles,ContributorRoles.NarrativeContributorRoles,Photo");
            if (contributorModel == null)
                throw new Exception($"Contributor with Id {id} not found.");

            var selectedGenreModels = expectedEntityValues.GenresId != null
                ? await genreRepo.GetAllAsync(g => expectedEntityValues.GenresId.Contains(g.Id))
                : new List<Genre>();
            contributorModel.Genres.Clear();
            contributorModel.Genres = selectedGenreModels.ToList();

            var selectedRoleModels = await roleRepo.GetAllAsync(r => expectedEntityValues.RolesId.Contains(r.Id));
            if (selectedRoleModels.Count() != expectedEntityValues.RolesId.Count())
                throw new ArgumentException("One or more specified roles do not exist.");

            var rolesToRemove = contributorModel.ContributorRoles
                .Where(cr => !expectedEntityValues.RolesId.Contains(cr.RoleId) && !cr.NarrativeContributorRoles.Any())
                .ToList();

            foreach (var roleToRemove in rolesToRemove)
            {
                contributorModel.ContributorRoles.Remove(roleToRemove);
            }

            foreach (var cr in contributorModel.ContributorRoles)
            {
                contributorRoleRepo.Attach(cr);
            }

            foreach (var role in selectedRoleModels)
            {
                if (!contributorModel.ContributorRoles.Any(cr => cr.RoleId == role.Id))
                {
                    contributorModel.ContributorRoles.Add(new ContributorRole { RoleId = role.Id, ContributorId = contributorModel.Id });
                }
            }

            if (expectedEntityValues.Photo is not null)
            {
                if (contributorModel.Photo != null)
                {
                    await photoRepo.Delete(contributorModel.Photo);
                }

                using (var memoryStream = new MemoryStream())
                {
                    await expectedEntityValues.Photo.CopyToAsync(memoryStream);
                    contributorModel.Photo = new Photo { Data = memoryStream.ToArray() };
                }
            }

            contributorModel = _mapper.Map(expectedEntityValues, contributorModel);
            contributorModel.Id = id;

            await contributorRepo.UpdateAsync(contributorModel);
            await _unitOfWork.CommitAsync();

            return true;
        }


        public async Task<ContributorViewModel?> GetByIdAsync(int? id)
        {
            if (id == null)
                return null;

            var contributorRepo = _unitOfWork.GetRepository<Contributor>();

            var contributorModel = await contributorRepo.GetAsync(
                filter: c => c.Id == id,
                includeOptions: "Genres,ContributorRoles.Role,Photo"
            );

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
