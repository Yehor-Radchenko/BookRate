using BookRate.DAL.Models;

namespace BookRate.DAL.DTO
{
    public class CreateShelfDTO
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; }

        public int UserId { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
