using System;
using System.Collections.Generic;

namespace BookRate.DAL.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public partial class Contributor
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
    public string FirstName { get; set; } = null!;

    [StringLength(50, ErrorMessage = "Patronymic cannot exceed 50 characters.")]
    public string? Patronymic { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? BirthDate { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? DeathDate { get; set; }

    [Required(ErrorMessage = "Biography is required.")]
    public string Biography { get; set; } = null!;

    [Required(ErrorMessage = "Birth place is required.")]
    [StringLength(100, ErrorMessage = "Birth place cannot exceed 100 characters.")]
    public string BirthPlace { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public virtual ICollection<ContributorRole> ContributorRoles { get; set; }

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (BirthDate.HasValue && DeathDate.HasValue && BirthDate > DeathDate)
        {
            yield return new ValidationResult("Birth date cannot be after death date.", new[] { "BirthDate", "DeathDate" });
        }
    }
}

