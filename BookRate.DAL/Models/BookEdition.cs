using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookRate.DAL.Models;

public partial class BookEdition
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Cover type is required.")]
    public int CoverType { get; set; }

    [Required(ErrorMessage = "Pages count is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Pages count must be a positive number.")]
    public int PagesCount { get; set; }

    [Required(ErrorMessage = "Edition date is required.")]
    [DataType(DataType.Date)]
    public DateTime EditionDate { get; set; }

    [Required(ErrorMessage = "ISBN is required.")]
    [RegularExpression(@"^\d{9}(\d|X)$", ErrorMessage = "Invalid ISBN format.")]
    [StringLength(13, MinimumLength = 10, ErrorMessage = "ISBN must contain 10 or 13 characters.")]
    public string Ibsn { get; set; } = null!;

    public int BookId { get; set; }

    public int EditionId { get; set; }

    [Url(ErrorMessage = "Invalid website URL.")]
    public string PhotoUrl { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Edition Edition { get; set; } = null!;
}
