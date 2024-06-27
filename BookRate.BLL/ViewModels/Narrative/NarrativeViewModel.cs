using BookRate.BLL.ViewModels.Contributor;
using BookRate.BLL.ViewModels.Genre;
using BookRate.BLL.ViewModels.Reward;
using BookRate.BLL.ViewModels.Setting;

namespace BookRate.BLL.ViewModels.Narrative
{
    public class NarrativeViewModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? OriginalTitle { get; set; }

        public string? ThreeLetterIsolanguageName { get; set; }

        public ICollection<ContributorListModel> Contributors { get; set; } = new List<ContributorListModel>();

        public ICollection<GenreListModel> Genres { get; set; } = new List<GenreListModel>();

        public ICollection<SettingViewModel> Settings { get; set; } = new List<SettingViewModel>();

        public ICollection<NarrativeRewardViewModel> Rewards { get; set; } = new List<NarrativeRewardViewModel>();
    }
}
