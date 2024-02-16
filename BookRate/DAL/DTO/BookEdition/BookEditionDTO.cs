namespace BookRate.DAL.DTO.BookEdition
{
    public class BookEditionDTO
    {
        public int CoverType { get; set; }

        public int PagesCount { get; set; }

        public DateTime EditionDate { get; set; }

        public string Ibsn { get; set; }

        public int BookId { get; set; }

        public int EditionId { get; set; }

        public byte[]? Photo { get; set; }
    }
}
