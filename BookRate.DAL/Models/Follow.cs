using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookRate.DAL.Models
{
    public class Follow
    {
        [Key, Column(Order = 0)]
        public int FolloweeId { get; set; }

        [Key, Column(Order = 1)]
        public int FollowerId { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime DateFollowed { get; set; }
    }
}
