using System;
using System.Collections.Generic;

namespace BookRate.DAL.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public byte[]? Photo { get; set; }

    public string? Interests { get; set; }

    public virtual ICollection<Commentary>? Commentaries { get; set; }

    public virtual ICollection<CommentaryLike>? CommentaryLikes { get; set; }

    public virtual ICollection<Rate>? Rates { get; set; }

    public virtual ICollection<ReviewLike>? ReviewLikes { get; set; }

    public virtual ICollection<Review>? Reviews { get; set; }
}
