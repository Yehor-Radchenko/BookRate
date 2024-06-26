﻿using AutoMapper;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.Narrative;
using BookRate.DAL.DTO.Genre;
using BookRate.DAL.DTO.Narrative;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace BookRate.BLL.Services
{
    public class NarrativeService : BaseService<Narrative, NarrativeDto>, IService<NarrativeDto>
    {
        public NarrativeService(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IValidator<NarrativeDto> validator
            ) : base(unitOfWork, mapper, validator)
        {
        }

        public async Task<int> AddAsync(NarrativeDto dto)
        {
            ValidationResult result = await _validator.ValidateAsync(dto);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var narrativeRepo = _unitOfWork.GetRepository<Narrative>();
            var contributorRoleRepo = _unitOfWork.GetRepository<ContributorRole>();
            var genreRepo = _unitOfWork.GetRepository<Genre>();
            var settingRepo = _unitOfWork.GetRepository<Setting>();
            var rewardRepo = _unitOfWork.GetRepository<Reward>();
            var roleRepo = _unitOfWork.GetRepository<Role>();

            await EnsureContributorWithAuthorRoleExists(dto.ContributorRoleIds);

            var narrative = _mapper.Map<Narrative>(dto);

            foreach (var genreId in dto.GenresId)
            {
                var genre = await genreRepo.GetAsync(g => g.Id == genreId);
                if (genre != null)
                {
                    narrative.Genres.Add(genre);
                }
            }

            if (dto.SettingsId != null)
            {
                foreach (var settingId in dto.SettingsId)
                {
                    var setting = await settingRepo.GetAsync(s => s.Id == settingId);
                    if (setting != null)
                    {
                        narrative.Settings.Add(setting);
                    }
                }
            }

            await narrativeRepo.AddAsync(narrative);
            await _unitOfWork.CommitAsync();

            narrative.NarrativeContributorRoles = new List<NarrativeContributorRole>();
            foreach (var contributorRoleId in dto.ContributorRoleIds)
            {
                var contributorRole = await contributorRoleRepo.GetAsync(cr => cr.Id == contributorRoleId);

                if (contributorRole != null)
                {
                    narrative.NarrativeContributorRoles.Add(new NarrativeContributorRole
                    {
                        ContributorRoleId = contributorRoleId,
                        NarrativeId = narrative.Id
                    });
                }
            }

            if (dto.NarrativeRewards != null)
            {
                narrative.NarrativeRewards = new List<NarrativeReward>();
                foreach (var rewardDto in dto.NarrativeRewards)
                {
                    var reward = await rewardRepo.GetAsync(r => r.Id == rewardDto.RewardId);
                    if (reward != null)
                    {
                        var narrativeReward = _mapper.Map<NarrativeReward>(rewardDto);
                        narrativeReward.NarrativeId = narrative.Id;
                        narrative.NarrativeRewards.Add(narrativeReward);
                    }
                }
            }

            await narrativeRepo.UpdateAsync(narrative);
            await _unitOfWork.CommitAsync();

            return narrative.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var narrativeRepo = _unitOfWork.GetRepository<Narrative>();

            var narrativeToDelete = await narrativeRepo.GetAsync(n => n.Id == id);

            if (narrativeToDelete is null)
                throw new Exception("Narrative can't be found.");

            await narrativeRepo.DeleteAsync(narrativeToDelete);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, NarrativeDto expectedEntityValues)
        {
            ValidationResult result = await _validator.ValidateAsync(expectedEntityValues);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var narrativeRepo = _unitOfWork.GetRepository<Narrative>();
            var contributorRoleRepo = _unitOfWork.GetRepository<ContributorRole>();
            var genreRepo = _unitOfWork.GetRepository<Genre>();
            var settingRepo = _unitOfWork.GetRepository<Setting>();
            var rewardRepo = _unitOfWork.GetRepository<Reward>();
            var roleRepo = _unitOfWork.GetRepository<Role>();

            var narrativeToUpdate = await narrativeRepo.GetAsync(n => n.Id == id, "NarrativeRewards,NarrativeContributorRoles,Genres,Settings");

            if (narrativeToUpdate == null)
                return false;

            await EnsureContributorWithAuthorRoleExists(expectedEntityValues.ContributorRoleIds);

            var updatedNarrative = _mapper.Map(expectedEntityValues, narrativeToUpdate);
            updatedNarrative.Id = id;

            updatedNarrative.NarrativeContributorRoles.Clear();
            foreach (var contributorRoleId in expectedEntityValues.ContributorRoleIds)
            {
                var contributorRole = await contributorRoleRepo.GetAsync(cr => cr.Id == contributorRoleId);
                if (contributorRole != null)
                {
                    updatedNarrative.NarrativeContributorRoles.Add(new NarrativeContributorRole
                    {
                        ContributorRoleId = contributorRole.Id,
                        NarrativeId = updatedNarrative.Id
                    });
                }
            }

            updatedNarrative.Genres.Clear();
            foreach (var genreId in expectedEntityValues.GenresId)
            {
                var genre = await genreRepo.GetAsync(g => g.Id == genreId);
                if (genre != null)
                    updatedNarrative.Genres.Add(genre);
            }

            updatedNarrative.Settings.Clear();
            if (expectedEntityValues.SettingsId != null)
            {
                foreach (var settingId in expectedEntityValues.SettingsId)
                {
                    var setting = await settingRepo.GetAsync(s => s.Id == settingId);
                    if (setting != null)
                        updatedNarrative.Settings.Add(setting);
                }
            }

            updatedNarrative.NarrativeRewards.Clear();
            if (expectedEntityValues.NarrativeRewards != null)
            {
                foreach (var nrDto in expectedEntityValues.NarrativeRewards)
                {
                    var narrativeReward = new NarrativeReward
                    {
                        NarrativeId = updatedNarrative.Id,
                        RewardId = nrDto.RewardId,
                        DateRewarded = nrDto.DateRewarded
                    };

                    updatedNarrative.NarrativeRewards.Add(narrativeReward);
                }
            }

            await narrativeRepo.UpdateAsync(updatedNarrative);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<IEnumerable<NarrativeListModel>> GetNarrativeListModelsAsync()
        {
            var narrativeRepo = _unitOfWork.GetRepository<Narrative>();

            var narrativesQuery = narrativeRepo.GetAll()
                .Include(n => n.NarrativeContributorRoles)
                    .ThenInclude(ncr => ncr.ContributorRole)
                        .ThenInclude(cr => cr.Contributor)
                .Where(n => n.NarrativeContributorRoles.Any(ncr => ncr.ContributorRole.Role.Name == "Author"));

            var list = await _mapper.ProjectTo<NarrativeListModel>(narrativesQuery).ToListAsync();

            return list;
        }

        public async Task<NarrativeViewModel?> GetByIdAsync(int? id)
        {
            if (id == null)
                return null;

            var narrativeRepo = _unitOfWork.GetRepository<Narrative>();

            var narrativeModel = await narrativeRepo.GetAsync(c => c.Id == id,
                "NarrativeContributorRoles.ContributorRole.Contributor,NarrativeContributorRoles.ContributorRole.Role,Genres,Settings,NarrativeRewards.Reward");

            if (narrativeModel == null)
                return null;

            return _mapper.Map<NarrativeViewModel>(narrativeModel);
        }

        private async Task EnsureContributorWithAuthorRoleExists(IEnumerable<int> contributorRoleIds)
        {
            var roleRepo = _unitOfWork.GetRepository<Role>();
            var contributorRoleRepo = _unitOfWork.GetRepository<ContributorRole>();

            var authorRole = await roleRepo.GetAsync(r => r.Name == "Author");
            if (authorRole == null)
                throw new Exception("Role 'Author' does not exist.");

            var contributorRoles = await contributorRoleRepo
                .GetAll()
                .Where(cr => contributorRoleIds.Contains(cr.Id))
                .ToListAsync();

            var hasAuthor = contributorRoles.Any(cr => cr.RoleId == authorRole.Id);

            if (!hasAuthor)
                throw new Exception("Cannot update narrative without at least one contributor with the role 'Author'.");
        }
    }
}
