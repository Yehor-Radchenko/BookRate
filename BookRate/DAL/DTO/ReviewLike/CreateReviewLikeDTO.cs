namespace BookRate.DAL.DTO
{
    public class CreateReviewLikeDTO
    {
        public int UserId { get; set; }

        public int ReviewId { get; set; }

        public DateTime DateLiked { get; set; }
    }
}
