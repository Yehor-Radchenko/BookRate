using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRate.DAL.Models;

public partial class Commentary
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    [Column(TypeName = "smalldatetime")]
    public DateTime DateCommented { get; set; }

    public int UserId { get; set; }

    public int ReviewId { get; set; }

    public virtual ICollection<CommentaryLike> CommentaryLikes { get; set; } = new List<CommentaryLike>();

    public virtual Review Review { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
