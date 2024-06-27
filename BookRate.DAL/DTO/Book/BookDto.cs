using BookRate.DAL.DTO.BookEdition;
using BookRate.DAL.DTO.Narrative;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.DTO.Book
{
    public class BookDto
    {
        public int? SerieId { get; set; }

        public string Title { get; set; }

        public DateTime FirstPublished { get; set; }

        public NarrativeDto Narrative { get; set; }

        public BookEditionDto BookEditionDTO { get; set; }
    }
}
