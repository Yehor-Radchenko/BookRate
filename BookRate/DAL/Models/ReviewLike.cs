using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRate.DAL.Models;

public partial class ReviewLike
{
    [Key, Column(Order = 0)]
    public int UserId { get; set; }

    [Key, Column(Order = 1)]
    public int ReviewId { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime DateLiked { get; set; }

    public virtual Review Review { get; set; }

    public virtual User User { get; set; }
}
