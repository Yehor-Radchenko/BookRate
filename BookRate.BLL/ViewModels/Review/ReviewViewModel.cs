

namespace BookRate.BLL.ViewModels.Review
{
    public class ReviewViewModel
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Text { get; init; }
        public DateTime DatePosted { get; init; }
        public string BookTitle { get; init; }
        public string Username { get; init; }
        public int NumberOfLikes { get; init; }

    }
}
