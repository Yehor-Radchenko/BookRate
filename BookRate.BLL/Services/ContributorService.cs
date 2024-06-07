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

            await _unitOfWork.GetRepository<Contributor>().AddAsync(contributor);
            await _unitOfWork.CommitAsync();

            return contributor.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var contributorRepo = _unitOfWork.GetRepository<Contributor>();

            var contributorExists = await contributorRepo.GetAsync(c => c.Id == id);
            if (contributorExists is null)
                throw new ArgumentException($"Contributor with Id {id} does not exist.", nameof(id));

            await contributorRepo.Delete(contributorExists);
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

            var contributorModel = await contributorRepo.GetAsync(c => c.Id == id, "Genres,ContributorRoles,Photo");
            if (contributorModel == null)
                throw new Exception($"Contributor with Id {id} not found.");

            contributorModel.ContributorRoles.Clear();
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
            foreach (var role in selectedRoleModels)
            {
                updatedContributor.ContributorRoles.Add(new ContributorRole { RoleId = role.Id, ContributorId = contributorModel.Id });
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
