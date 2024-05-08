using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRate.DAL.Models;

public partial class Review
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Text { get; set; } = null!;

    [Column(TypeName = "smalldatetime")]
    public DateTime DatePosted { get; set; }

    public DateTime? StartReadDate { get; set; }

    public DateTime? EndReadDate { get; set; }

    public int BookId { get; set; }

    public int UserId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual ICollection<Commentary> Commentaries { get; set; } = new List<Commentary>();

    public virtual ICollection<ReviewLike> ReviewLikes { get; set; } = new List<ReviewLike>();

    public virtual User User { get; set; } = null!;

    [Column(TypeName = "timestamp")]
    public byte[] Timestamp { get; set; }
}
