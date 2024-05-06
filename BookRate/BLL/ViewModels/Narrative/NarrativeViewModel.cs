using BookRate.DAL.Models;

namespace BookRate.BLL.ViewModels
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
