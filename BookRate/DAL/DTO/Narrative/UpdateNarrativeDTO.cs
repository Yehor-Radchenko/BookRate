namespace BookRate.DAL.DTO
{
    public class UpdateNarrativeDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string? OriginalTitle { get; set; }

        public string ThreeLetterIsolanguageName { get; set; }

        public virtual IEnumerable<int> ContributorsId { get; set; }

        public virtual IEnumerable<int> GenresId { get; set; }

        public virtual IEnumerable<int>? SettingsId { get; set; }

        public virtual IEnumerable<int>? NarrativeRewards { get; set; }
    }
}
