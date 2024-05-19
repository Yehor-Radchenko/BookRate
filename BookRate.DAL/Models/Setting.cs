using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookRate.DAL.Models;

public partial class Setting
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Setting name is required.")]
    [StringLength(100, ErrorMessage = "Setting name cannot exceed 100 characters.")]
    [RegularExpression(@"^[A-Za-zА-Яа-яЁёЇїІіЄєҐґ]+(?:\s[A-Za-zА-Яа-яЁёЇїІіЄєҐґ]+)*$",
        ErrorMessage = "Setting name must consist of words separated by a single space.")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Narrative> Narratives { get; set; } = new List<Narrative>();
}
