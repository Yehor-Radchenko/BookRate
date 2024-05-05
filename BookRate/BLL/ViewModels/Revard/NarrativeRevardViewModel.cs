namespace BookRate.BLL.ViewModels
{
    public class NarrativeRevardViewModel
    {
        public int Id { get; set; }

        public int NarrativeId { get; set; }

        public int RevardId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Website { get; set; }

        public DateTime DateRevarded { get; set; }
    }
}
