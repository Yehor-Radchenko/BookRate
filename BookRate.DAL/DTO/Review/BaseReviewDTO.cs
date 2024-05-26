using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.DTO.Review
{
    public abstract class BaseReviewDTO
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime DatePosted { get; set; }

        public DateTime? StartReadDate { get; set; }

        public DateTime? EndReadDate { get; set; }

        public int BookId { get; set; }

        public int UserId { get; set; }
    }
}
