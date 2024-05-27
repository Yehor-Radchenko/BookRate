using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRate.DAL.Models;

public partial class Review
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title
    {
        get => _title;
        set => _title = value?.Trim();
    }
    private string _title = null!;

    [Required(ErrorMessage = "Text is required.")]
    public string Text
    {
        get => _text;
        set => _text = value?.Trim();
    }
    private string _text = null!;

    [Required]
    [Column(TypeName = "smalldatetime")]
    public DateTime DatePosted { get; set; }

    [DataType(DataType.Date)]
    public DateTime? StartReadDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? EndReadDate { get; set; }

    [Required]
    public int BookId { get; set; }

    [Required]
    public int UserId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual ICollection<Commentary> Commentaries { get; set; } = new List<Commentary>();

    public virtual ICollection<ReviewLike> ReviewLikes { get; set; } = new List<ReviewLike>();

    public virtual User User { get; set; } = null!;

    [Column(TypeName = "timestamp")]
    public byte[] Timestamp { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(Title))
        {
            yield return new ValidationResult("Title cannot be empty or whitespace.", new[] { nameof(Title) });
        }

        if (string.IsNullOrWhiteSpace(Text))
        {
            yield return new ValidationResult("Text cannot be empty or whitespace.", new[] { nameof(Text) });
        }

        if (StartReadDate.HasValue && EndReadDate.HasValue && StartReadDate.Value >= EndReadDate.Value)
        {
            yield return new ValidationResult("Start read date must be before end read date.",
                new[] { nameof(StartReadDate), nameof(EndReadDate) });
        }
    }
}
