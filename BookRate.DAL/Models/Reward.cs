using System;
using System.Collections.Generic;

namespace BookRate.DAL.Models;

using System.ComponentModel.DataAnnotations;

public partial class Reward
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Reward name is required.")]
    [StringLength(100, ErrorMessage = "Reward name cannot exceed 100 characters.")]
    [RegularExpression(@"^[A-Za-zА-Яа-яЁёЇїІіЄєҐґ]+(?:\s[A-Za-zА-Яа-яЁёЇїІіЄєҐґ]+)*$",
        ErrorMessage = "Reward name must consist of words separated by a single space.")]
    public string Name { get; set; } = null!;

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string? Description { get; set; }

    [Url(ErrorMessage = "Website must be a valid URL.")]
    public string? Website { get; set; }

    public virtual ICollection<NarrativeReward> NarrativeRewards { get; set; } = new List<NarrativeReward>();
}

