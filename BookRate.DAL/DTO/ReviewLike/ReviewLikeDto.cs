namespace BookRate.DAL.DTO.ReviewLike
{
    public class ReviewLikeDto
    {
        public int UserId { get; set; }

        public int ReviewId { get; set; }

        public DateTime DateLiked { get; set; }
    }
}
