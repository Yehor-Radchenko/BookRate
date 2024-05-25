using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookRate.DAL.Models;

public class Narrative
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(100, ErrorMessage = "Title length cannot exceed 100 characters.")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; } = null!;

    [StringLength(100, ErrorMessage = "Original title length cannot exceed 100 characters.")]
    public string? OriginalTitle { get; set; }

    [Required(ErrorMessage = "ThreeLetterIsolanguageName is required.")]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "ThreeLetterIsolanguageName must be exactly 3 characters.")]
    public string ThreeLetterIsolanguageName { get; set; } = null!;

    public virtual ICollection<NarrativeReward> NarrativeRewards { get; set; } = new List<NarrativeReward>();

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    [Required(ErrorMessage = "At least one narrative contributor is required.")]
    [MinLength(1, ErrorMessage = "At least one narrative contributor is required.")]
    public virtual ICollection<NarrativeContributorRole> NarrativeContributorRoles { get; set; }

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();

    public virtual ICollection<Setting> Settings { get; set; } = new List<Setting>();
}
