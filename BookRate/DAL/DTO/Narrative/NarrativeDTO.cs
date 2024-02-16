using BookRate.DAL.Models;

namespace BookRate.DAL.DTO
{
    public class NarrativeDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; } 

        public string? OriginalTitle { get; set; }

        public string ThreeLetterIsolanguageName { get; set; } 

        public virtual IEnumerable<Contributor> Contributors { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
    }
}
