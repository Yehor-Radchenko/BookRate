using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookRate.DAL.DTO
{
    public class ReviewLikeDTO
    {
        public int UserId { get; set; }

        public int ReviewId { get; set; }

        public DateTime DateLiked { get; set; }
    }
}
