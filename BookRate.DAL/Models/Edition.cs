using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookRate.DAL.Models;

public partial class Edition
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Edition name length cannot exceed 100 characters.")]
    public string Name { get; set; } = null!;

    [Url(ErrorMessage = "Invalid website URL.")]
    public string? Website { get; set; }

    public virtual ICollection<BookEdition> BookEditions { get; set; } = new List<BookEdition>();
}
