using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.DTO.Commentary
{
    public abstract class BaseCommentaryDTO
    {
        public int UserId { get; set; }

        public int ReviewId { get; set; }

        public string Text { get; set; }

        public DateTime DateCommented { get; set; }
    }
}
