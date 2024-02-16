using System.ComponentModel.DataAnnotations.Schema;

namespace BookRate.DAL.DTO
{
    public class RateDTO
    {
        public int UserId { get; set; }

        public int BookId { get; set; }

        public int StarsRate { get; set; }

        public DateTime DateRated { get; set; }
    }
}
