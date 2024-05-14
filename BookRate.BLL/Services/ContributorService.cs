using AutoMapper;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.DAL.DTO.Contributor;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
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
            contributor.Roles = selectedRoleModels.ToList();

            await _unitOfWork.GetRepository<Contributor>().AddAsync(contributor);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var contributorRepo = _unitOfWork.GetRepository<Contributor>();

            if (contributorRepo.Exists(g => g.Id == id && g.Narratives.Any()))
                throw new Exception("Contributor can't be removed because it referenced by at least one narrative.");

            await contributorRepo.Delete(new Contributor { Id = id });
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(UpdateContributorDTO expectedEntityValues)
        {
            var contributorRepo = _unitOfWork.GetRepository<Contributor>();
            var roleRepo = _unitOfWork.GetRepository<Role>();
            var genreRepo = _unitOfWork.GetRepository<Genre>();

            var contributorModel = await contributorRepo.GetAsync(c => c.Id == expectedEntityValues.Id);
            contributorModel.Roles.Clear();
            contributorModel.Genres.Clear();

            var contributorResult = _mapper.Map(expectedEntityValues, contributorModel);
            foreach (var id in expectedEntityValues.Roles)
            {
                contributorResult.Roles.Add(await roleRepo.GetAsync(r => r.Id == id));
            }
            foreach (var id in expectedEntityValues.Genres)
            {
                contributorResult.Genres.Add(await genreRepo.GetAsync(g => g.Id == id));
            }

            await contributorRepo.UpdateAsync(contributorResult);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
