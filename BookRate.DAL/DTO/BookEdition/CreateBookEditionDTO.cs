namespace BookRate.DAL.DTO.BookEdition
{
    public class CreateBookEditionDTO
    {
        public int BookId { get; set; }

        public int EditionId { get; set; }

        public int CoverType { get; set; }

        public int PagesCount { get; set; }

        public DateTime EditionDate { get; set; }

        public string Ibsn { get; set; }

        public byte[]? Photo { get; set; }
    }
}
