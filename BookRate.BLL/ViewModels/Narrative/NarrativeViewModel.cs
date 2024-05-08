using BookRate.BLL.ViewModels.Contributor;
using BookRate.BLL.ViewModels.Genre;
using BookRate.BLL.ViewModels.Reward;
using BookRate.BLL.ViewModels.Setting;
using BookRate.DAL.Models;

namespace BookRate.BLL.ViewModels.Narrative
{
    public class NarrativeViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string? OriginalTitle { get; set; }

        public string ThreeLetterIsolanguageName { get; set; }

        public IEnumerable<ContributorListModel> Contributors { get; set; }

        public IEnumerable<GenreListModel> Genres { get; set; }

        public IEnumerable<SettingViewModel> Settings { get; set; }

        public IEnumerable<NarrativeRewardViewModel> NarrativeRewards { get; set; }
    }
}
