namespace BookRate.BLL.ViewModels.Book
{
    public class BookCardViewModel
    {
        public int BookId { get; set; }

        public string? Title { get; set; }

        public ICollection<string>? Authors { get; set; } = new List<string>();

        public double AverageRate { get; set; }
        public string EditionName { get; set; }

        public byte[]? Photo { get; set; }
    }
}
