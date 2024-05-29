using BookRate.DAL.DTO.BookEdition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.DTO.Book
{
    public abstract class BaseBookDTO
    {
        public int? SerieId { get; set; }

        public string Title { get; set; }

        public DateTime FirstPublished { get; set; }

        public virtual IEnumerable<int> NarrativesId { get; set; }

        public BaseBookEditionDTO BookEditionDTO { get; set; }
    }
}
