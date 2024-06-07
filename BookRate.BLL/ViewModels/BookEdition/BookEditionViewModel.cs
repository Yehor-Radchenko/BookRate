namespace BookRate.BLL.ViewModels.BookEdition
{
    public class BookEditionViewModel
    {
        public int Id { get; set; }

        public int CoverType { get; set; }

        public int PagesCount { get; set; }

        public DateTime EditionDate { get; set; }

        public string Isbn { get; set; }

        public int BookId { get; set; }

        public int EditionId { get; set; }

        public string EditionName { get; set; }

        public byte[] Photo { get; set; }
    }
}

