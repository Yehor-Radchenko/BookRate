using BookRate.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRate.DAL.DTO.Commentary
{
    public class CommentaryDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ReviewId { get; set; }

        public string Text { get; set; }

        public DateTime DateCommented { get; set; }
    }
}
