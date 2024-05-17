using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookRate.DAL.Models;

public partial class CommentaryLike
{
    [Key, Column(Order = 0)]
    public int UserId { get; set; }

    [Key, Column(Order = 1)]
    public int CommentaryId { get; set; }

    public bool IsLiked { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime DateLiked { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; } = null!;

    [ForeignKey("CommentaryId")]
    public virtual Commentary Commentary { get; set; } = null!;
}

