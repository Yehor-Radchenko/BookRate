using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels.Narrative;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;
using BookRate.DAL.DTO.Narrative;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.BLL.Services
{
    public class NarrativeService : INarrativeService
    {
        private readonly INarrativeRepository _narrativeRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IContributorRepository _contributorRepository;
        private readonly ISettingRepository _settingRepository;
        private readonly IMapper _mapper;

        public NarrativeService(
            INarrativeRepository narrativeRepository,
            IGenreRepository genreRepository,
            IContributorRepository contributorRepository,
            IMapper mapper) 
        {
            _narrativeRepository = narrativeRepository;
            _genreRepository = genreRepository;
            _contributorRepository = contributorRepository;
            _mapper = mapper;
        }

        public async Task<bool> Add(CreateNarrativeDTO dto)
        {
            List<Contributor> selectedContributorModels = new List<Contributor>();
            List<Genre> selectedGenreModels = new List<Genre>();
            List<Setting> selectedSettingModels = new List<Setting>();
            bool isAnyContributorFillsAuthorRole = false;

            foreach (var contributorId in dto.ContributorsId)
            {
                Contributor contributor = await _contributorRepository.GetByIdAsync(contributorId);

                if (contributor.Roles.Any(r => r.Name == "Author"))
                    isAnyContributorFillsAuthorRole = true;
                selectedContributorModels.Add(contributor);
            }

            if (!isAnyContributorFillsAuthorRole)
                throw new Exception("You trying to create narrative without contributor with role Author.");

            foreach (var id in dto.GenresId)
            {
                Genre model = await _genreRepository.GetByIdAsync(id);
                if (model is null)
                    throw new Exception($"Can't create Narrative: genre with ID {id} not found.");
                else
                    selectedGenreModels.Add(model);
            }

            foreach (var id in dto.SettingsId)
            {
                Setting model = await _settingRepository.GetByIdAsync(id);
                if (model is null)
                    throw new Exception($"Can't create Narrative: setting with ID {id} not found.");

                selectedSettingModels.Add(model);
            }

            try
            {
                await _narrativeRepository.Add(_mapper.Map<Narrative>(dto));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            if(_narrativeRepository.IsAnyBookReferenced(id))
                throw new Exception("Narrative can't be removed because it referenced by at least one book.");

            try
            {
                await _narrativeRepository.Delete(new Narrative { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<NarrativeViewModel>> GetAll()
        {
            try
            {
                IEnumerable<Narrative> narrativeModels = await _narrativeRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<NarrativeViewModel>>(narrativeModels);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving narratives.", ex);
            }
        }

        public async Task<NarrativeViewModel?> GetById(int? id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Id is null.");

                Narrative? narrativeModel = await _narrativeRepository.GetByIdAsync(id.Value);

                if (narrativeModel == null)
                    throw new Exception($"There is no narrative with Id {id}");

                return _mapper.Map<NarrativeViewModel>(narrativeModel);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving narrative.", ex);
            }
        }

        public async Task<bool> Update(UpdateNarrativeDTO expectedEntityValues)
        {
            try
            {
                bool isAnyContributorFillsAuthorRole = false;
                foreach (var contributorId in expectedEntityValues.ContributorsId)
                {
                    Contributor contributor = await _contributorRepository.GetByIdAsync(contributorId);
                    if (contributor.Roles.Any(r => r.Name == "Author"))
                    {
                        isAnyContributorFillsAuthorRole = true;
                        break;
                    }
                }

                if (!isAnyContributorFillsAuthorRole)
                    throw new Exception("You cannot update narrative without a contributor with role Author.");

                var narrativeModel = _mapper.Map<Narrative>(expectedEntityValues);

                await _narrativeRepository.Update(narrativeModel);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating narrative.", ex);
            }
        }
    }
}
