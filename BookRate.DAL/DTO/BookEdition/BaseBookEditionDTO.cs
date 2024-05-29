using BookRate.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.DTO.BookEdition
{
    public abstract class BaseBookEditionDTO
    {
        public int BookId { get; set; }

        public int EditionId { get; set; }

        public CoverType CoverType { get; set; }

        public int PagesCount { get; set; }

        public DateTime EditionDate { get; set; }

        public string Ibsn { get; set; }

        public byte[]? Photo { get; set; }
    }
}
