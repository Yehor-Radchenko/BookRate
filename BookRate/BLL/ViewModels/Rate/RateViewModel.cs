using System.ComponentModel.DataAnnotations.Schema;

namespace BookRate.BLL.ViewModels
{
    public class RateViewModel
    {
        public int UserId { get; set; }

        public int BookId { get; set; }

        public int StarsRate { get; set; }

        public DateTime DateRated { get; set; }
    }
}
