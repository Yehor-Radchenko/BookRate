using AutoMapper;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.Contributor;
using BookRate.DAL.DTO.Contributor;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BookRate.BLL.Services
{
    public class ContributorService : BaseService<Contributor, CreateContributorDTO, UpdateContributorDTO>
    {
        public ContributorService(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IValidator<BaseContributorDTO> validator
            ) : base(unitOfWork, mapper, validator)
        { 
        }

        public async override Task<int> AddAsync(CreateContributorDTO dto)
        {
            if (dto.RolesId == null || !dto.RolesId.Any())
                throw new ArgumentException("Contributor must have at least one role.", nameof(dto.RolesId));

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

            await _unitOfWork.GetRepository<Contributor>().AddAsync(contributor);
            await _unitOfWork.CommitAsync();

            return contributor.Id;
        }

        public async override Task<bool> Delete(int id)
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

        public async override Task<bool> UpdateAsync(UpdateContributorDTO expectedEntityValues)
        {
            if (expectedEntityValues.RolesId == null || !expectedEntityValues.RolesId.Any())
                throw new ArgumentException("Contributor must have at least one role.", nameof(expectedEntityValues.RolesId));

            var contributorRepo = _unitOfWork.GetRepository<Contributor>();
            var roleRepo = _unitOfWork.GetRepository<Role>();
            var genreRepo = _unitOfWork.GetRepository<Genre>();

            var contributorModel = await contributorRepo.GetAsync(c => c.Id == expectedEntityValues.Id, "Genres,ContributorRoles");

            if (contributorModel == null)
                throw new Exception($"Contributor with Id {expectedEntityValues.Id} not found.");

            contributorModel.ContributorRoles.Clear();
            contributorModel.Genres.Clear();

            var selectedRoleModels = await roleRepo.GetAllAsync(r => expectedEntityValues.RolesId.Contains(r.Id));
            var selectedGenreModels = expectedEntityValues.GenresId != null ? await genreRepo.GetAllAsync(g => expectedEntityValues.GenresId.Contains(g.Id)) : new List<Genre>();

            _mapper.Map(expectedEntityValues, contributorModel);

            foreach (var role in selectedRoleModels)
            {
                contributorModel.ContributorRoles.Add(new ContributorRole
                {
                    ContributorId = contributorModel.Id,
                    RoleId = role.Id
                });
            }

            foreach (var genre in selectedGenreModels)
            {
                contributorModel.Genres.Add(genre);
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

            var contributorModel = await contributorRepo.GetAsync(
                filter: c => c.Id == id,
                includeOptions: "Genres,ContributorRoles.Role"
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
