namespace BookRate.DAL.Models
{
    public class Shelf
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public List<Book> Books { get; set; }
        public virtual User User { get; set; }
    }
}
