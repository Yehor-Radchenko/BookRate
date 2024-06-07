namespace BookRate.DAL.DTO.CommentaryLike
{
    public class CommentaryLikeDto
    {
        public int UserId { get; set; }

        public int CommentaryId { get; set; }

        public bool IsLiked { get; set; }

        public DateTime DateLiked { get; set; }
    }
}
