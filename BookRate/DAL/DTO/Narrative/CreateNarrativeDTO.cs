using BookRate.BLL.ViewModels;

namespace BookRate.DAL.DTO
{
    public class CreateNarrativeDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string? OriginalTitle { get; set; }

        public string ThreeLetterIsolanguageName { get; set; }

        public virtual IEnumerable<int> ContributorsId { get; set; }

        public virtual IEnumerable<int> GenresId { get; set; }

        public virtual IEnumerable<int>? SettingsId { get; set; }

        public virtual IEnumerable<int>? RevardsId { get; set; }
    }
}
