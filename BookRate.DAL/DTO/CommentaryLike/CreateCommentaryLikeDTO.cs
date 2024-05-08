namespace BookRate.DAL.DTO.CommentaryLike
{
    public class CreateCommentaryLikeDTO
    {
        public int UserId { get; set; }

        public int CommentaryId { get; set; }

        public DateTime DateLiked { get; set; }
    }
}
