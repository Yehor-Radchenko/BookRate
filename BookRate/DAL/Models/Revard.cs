using System;
using System.Collections.Generic;

namespace BookRate.DAL.Models;

public partial class Revard
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Website { get; set; }

    public virtual ICollection<NarrativeRevard> NarrativeRevards { get; set; } = new List<NarrativeRevard>();
}
