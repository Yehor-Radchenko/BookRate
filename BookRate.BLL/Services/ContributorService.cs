﻿using AutoMapper;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.Contributor;
using BookRate.DAL.DTO.Contributor;
using BookRate.DAL.Models;
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

        public async Task<bool> DeleteAsync(int id)
        {
            var contributorRepo = _unitOfWork.GetRepository<Contributor>();

            var contributorExists = await contributorRepo.GetAsync(c => c.Id == id);
            if (contributorExists is null)
                throw new ArgumentException($"Contributor with Id {id} does not exist.", nameof(id));

            await contributorRepo.DeleteAsync(contributorExists);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, ContributorDto expectedEntityValues)
        {
            ValidationResult result = await _validator.ValidateAsync(expectedEntityValues);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var contributorRepo = _unitOfWork.GetRepository<Contributor>();
            var roleRepo = _unitOfWork.GetRepository<Role>();
            var genreRepo = _unitOfWork.GetRepository<Genre>();
            var photoRepo = _unitOfWork.GetRepository<Photo>();

            var contributorModel = await contributorRepo.GetAsync(c => c.Id == id, "Genres,ContributorRoles,ContributorRoles.NarrativeContributorRoles,Photo");
            if (contributorModel == null)
                throw new Exception($"Contributor with Id {id} not found.");

            foreach(var cr in contributorModel.ContributorRoles.ToList())
            {
                if(cr.NarrativeContributorRoles.Count > 0)
                {
                    continue;
                }
                else contributorModel.ContributorRoles.Remove(cr);
            }

            contributorModel.Genres.Clear();

            var selectedRoleModels = await roleRepo.GetAllAsync(r => expectedEntityValues.RolesId.Contains(r.Id));
            var selectedGenreModels = expectedEntityValues.GenresId != null ? await genreRepo.GetAllAsync(g => expectedEntityValues.GenresId.Contains(g.Id)) : new List<Genre>();

            if (selectedRoleModels.Count() != expectedEntityValues.RolesId.Count())
                throw new ArgumentException("One or more specified roles do not exist.");

            if (expectedEntityValues.GenresId != null && selectedGenreModels.Count() != expectedEntityValues.GenresId.Count())
                throw new ArgumentException("One or more specified genres do not exist.");

            var updatedContributor = _mapper.Map(expectedEntityValues, contributorModel);
            updatedContributor.Id = id;
            updatedContributor.Genres = selectedGenreModels.ToList();

            foreach (var role in selectedRoleModels.Where(role => !updatedContributor.ContributorRoles.Any(cr => cr.RoleId == role.Id)))
            {
                updatedContributor.ContributorRoles.Add(new ContributorRole { RoleId = role.Id, ContributorId = contributorModel.Id });
            }

            if (expectedEntityValues.Photo is not null)
            {
                if (contributorModel.Photo != null)
                {
                    await photoRepo.DeleteAsync(contributorModel.Photo);
                }

                using (var memoryStream = new MemoryStream())
                {
                    await expectedEntityValues.Photo.CopyToAsync(memoryStream);
                    contributorModel.Photo = new Photo { Data = memoryStream.ToArray() };
                }
            }

            await contributorRepo.UpdateAsync(updatedContributor);
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
