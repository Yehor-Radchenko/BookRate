namespace BookRate.DAL.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Shelf
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Shelf name length cannot exceed 100 characters.")]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int UserId { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();

        public virtual User User { get; set; }
    }

}
