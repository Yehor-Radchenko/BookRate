using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace BookRate.DAL.Models;

public partial class Rate
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int BookId { get; set; }

    [Range(1, 5, ErrorMessage = "Stars rate must be between 1 and 5.")]
    public int StarsRate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime DateRated { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Review>? Reviews { get; set; }

    public byte[] Timestamp { get; set; }
}
