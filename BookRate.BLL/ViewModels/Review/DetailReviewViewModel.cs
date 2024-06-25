namespace BookRate.BLL.ViewModels.Review
{
    public class DetailReviewViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime DatePosted { get; set; }

        public DateTime? StartReadDate { get; set; }

        public DateTime? EndReadDate { get; set; }

        public int BookId { get; set; }

        public string BookName { get; set; }

        public int UserId { get; set; }

        public string Username { get; set; }

        public int NumberOfLikes { get; set; }
    }
}
