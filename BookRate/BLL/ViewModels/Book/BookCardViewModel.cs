namespace BookRate.BLL.ViewModels
{
    public class BookCardViewModel
    {
        public int BookId { get; set; }

        public string? Title { get; set; }

        public IEnumerable<string>? Authors { get; set; }

        public double AverageRate { get; set; }
        
        public byte[]? Photo {  get; set; }
    }
}
