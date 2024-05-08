using BookRate.DAL.Models;

namespace BookRate.DAL.DTO.Shelf
{
    public class UpdateShelfDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; }

        public int UserId { get; set; }

        public List<BookRate.DAL.Models.Book> Books { get; set; } = new List<BookRate.DAL.Models.Book>();
    }
}
