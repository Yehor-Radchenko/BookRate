using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookRate.DAL.Models;

public partial class Serie
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Series name is required.")]
    [StringLength(100, ErrorMessage = "Series name cannot exceed 100 characters.")]
    [RegularExpression(@"^[A-Za-zА-Яа-яЁёЇїІіЄєҐґ]+(?:\s[A-Za-zА-Яа-яЁёЇїІіЄєҐґ]+)*$",
       ErrorMessage = "Series name must consist of words separated by a single space.")]
    public string Name { get; set; } = null!;

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string? Description { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
