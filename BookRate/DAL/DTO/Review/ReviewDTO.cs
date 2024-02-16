namespace BookRate.DAL.DTO.Review
{
    public class ReviewDTO
    {
        public string Title { get; set; } 

        public string Text { get; set; } 

        public DateTime DatePosted { get; set; }

        public DateTime? StartReadDate { get; set; }

        public DateTime? EndReadDate { get; set; }

        public int BookId { get; set; }

        public int UserId { get; set; }
    }
}
