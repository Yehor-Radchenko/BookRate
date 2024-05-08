using BookRate.DAL.Models;

namespace BookRate.DAL.DTO.Shelf
{
    public class CreateShelfDTO
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; }

        public int UserId { get; set; }

        public IEnumerable<BookRate.DAL.Models.Book> Books { get; set; }
    }
}
