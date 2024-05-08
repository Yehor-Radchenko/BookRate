using BookRate.DAL.DTO.BookEdition;

namespace BookRate.DAL.DTO.Book
{
    public class CreateBookDTO
    {
        public int? SerieId { get; set; }

        public string Title { get; set; }

        public DateTime FirstPublished { get; set; }

        public virtual IEnumerable<int> NarrativesId { get; set; }

        public CreateBookEditionDTO createBookEditionDTO { get; set; }
    }
}
