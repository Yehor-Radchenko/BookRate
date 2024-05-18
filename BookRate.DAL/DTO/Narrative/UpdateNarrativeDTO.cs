using BookRate.DAL.DTO.NarrativeRevard;

namespace BookRate.DAL.DTO.Narrative
{
    public class UpdateNarrativeDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string? OriginalTitle { get; set; }

        public string ThreeLetterIsolanguageName { get; set; }

        public virtual IEnumerable<int> ContributorRoleIds { get; set; }

        public virtual IEnumerable<int> GenresId { get; set; }

        public virtual IEnumerable<int>? SettingsId { get; set; }

        public virtual IEnumerable<CreateNarrativeRewardDTO>? NarrativeRewards { get; set; }
    }
}
