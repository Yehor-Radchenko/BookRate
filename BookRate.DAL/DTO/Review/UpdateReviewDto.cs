using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.DTO.Review
{
    public class UpdateReviewDto
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime DateUpdate { get; set; }

        public DateTime? StartReadDate { get; set; }

        public DateTime? EndReadDate { get; set; }

        [Range(1, 5)]
        public int RateStarts { get; set; }
    }
}
