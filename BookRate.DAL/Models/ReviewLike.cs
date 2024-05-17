using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRate.DAL.Models;

public partial class ReviewLike
{
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }

    [ForeignKey(nameof(Review))]
    public int ReviewId { get; set; }

    public bool IsLiked { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime DateLiked { get; set; }

    public virtual Review Review { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }
}
