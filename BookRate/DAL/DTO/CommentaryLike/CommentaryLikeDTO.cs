using BookRate.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookRate.DAL.DTO
{
    public class CommentaryLikeDTO
    {
        public int UserId { get; set; }

        public int CommentaryId { get; set; }

        public DateTime DateLiked { get; set; }
    }
}
