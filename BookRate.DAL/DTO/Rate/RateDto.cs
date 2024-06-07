using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.DTO.Rate
{
    public class RateDto
    {
        public int UserId { get; set; }

        public int BookId { get; set; }

        public int StarsRate { get; set; }

        public DateTime DateRated { get; set; }
    }
}
