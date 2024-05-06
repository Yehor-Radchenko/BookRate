namespace BookRate.BLL.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime FirstPublished { get; set; }

        public BookEditionViewModel BookEdition { get; set; }

        public double AverageRate { get; set; }

        public int? SerieId { get; set; }

        public string? SerieName { get; set; }

        public IEnumerable<NarrativeViewModel> Narratives { get; set; }
    }
}
