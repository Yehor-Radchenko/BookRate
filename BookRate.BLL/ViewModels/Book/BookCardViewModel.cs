namespace BookRate.BLL.ViewModels.Book
{
    public class BookCardViewModel
    {
        public int BookId { get; set; }

        public string? Title { get; set; }

        public IEnumerable<string>? Authors { get; set; }

        public double AverageRate { get; set; }

        public byte[]? Photo { get; set; }
    }
}
