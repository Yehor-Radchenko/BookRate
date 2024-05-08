using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRate.DAL.Models;

public partial class Rate
{
    public int UserId { get; set; }

    public int BookId { get; set; }

    public int StarsRate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime DateRated { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public byte[] Timestamp { get; set; }
}
