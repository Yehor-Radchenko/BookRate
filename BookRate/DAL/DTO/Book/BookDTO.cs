using BookRate.DAL.Models;

namespace BookRate.DAL.DTO.Book
{
    public class BookDTO
    {
        public int? SerieId { get; set; }

        public DateTime FirstPublished { get; set; }

        public virtual IEnumerable<Narrative> Narratives { get; set; }
    }
}
