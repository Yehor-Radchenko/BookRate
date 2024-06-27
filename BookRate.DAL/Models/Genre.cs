using System.ComponentModel.DataAnnotations;

namespace BookRate.DAL.Models;

public partial class Genre
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Genre name is required.")]
    [StringLength(100, ErrorMessage = "Genre name cannot exceed 100 characters.")]
    [RegularExpression(@"^[A-Za-zА-Яа-яЁёЇїІіЄєҐґ]+(?:\s[A-Za-zА-Яа-яЁёЇїІіЄєҐґ]+)*$",
       ErrorMessage = "Genre name must consist of words separated by a single space.")]
    public string Name { get; set; } = null!;

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string? Description { get; set; }

    public virtual ICollection<Narrative> Narratives { get; set; } = new List<Narrative>();

    public virtual ICollection<Contributor> Contributors { get; set; } = new List<Contributor>();
}
