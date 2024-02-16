using BookRate.DAL.Models;

namespace BookRate.DAL.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }

        public int? SerieId { get; set; }

        public DateTime FirstPublished { get; set; }

        public virtual IEnumerable<Narrative> Narratives { get; set; }
    }
}
