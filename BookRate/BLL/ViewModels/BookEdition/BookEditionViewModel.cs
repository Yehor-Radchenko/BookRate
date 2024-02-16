namespace BookRate.BLL.ViewModels
{
    public class BookEditionViewModel
    {
        public int Id { get; set; }

        public int CoverType { get; set; }

        public int PagesCount { get; set; }

        public DateTime EditionDate { get; set; }

        public string Ibsn { get; set; }

        public int BookId { get; set; }

        public EditionViewModel Edition { get; set; }

        public byte[] Photo { get; set; }
    }
}

