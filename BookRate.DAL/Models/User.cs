using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRate.DAL.Models;

public partial class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
    public string Password { get; set; } = null!;

    [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username must contain only letters, numbers, or underscores.")]
    [StringLength(50, ErrorMessage = "Username must be at most 50 characters long.")]
    [MinLength(4, ErrorMessage = "Username must be at least 4 characters long.")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "First name is required.")]
    public string FirstName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public int? PhotoId { get; set; }

    public Photo? Photo { get; set; }

    [MaxLength(100, ErrorMessage = "Interests cannot exceed 100 characters.")]
    public string? Interests { get; set; }

    public virtual ICollection<Commentary>? Commentaries { get; set; }

    public virtual ICollection<CommentaryLike>? CommentaryLikes { get; set; }

    public virtual ICollection<Rate>? Rates { get; set; }

    public virtual ICollection<ReviewLike>? ReviewLikes { get; set; }

    public virtual ICollection<Review>? Reviews { get; set; }

    public virtual ICollection<Role>? Roles { get; set; } = new HashSet<Role>();

    [Timestamp]
    [Column(TypeName = "timestamp")]
    public byte[] Timestamp { get; set; }

    public bool IsGetBan { get; set; }
}
