using System;
using System.Collections.Generic;

namespace BookRate.DAL.Models;

public partial class Genre
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Narrative> Narratives { get; set; } = new List<Narrative>();

    public virtual ICollection<Contributor> Contributors { get; set; } = new List<Contributor>();
}
