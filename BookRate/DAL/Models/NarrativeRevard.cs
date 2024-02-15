using System;
using System.Collections.Generic;

namespace BookRate.DAL.Models;

public partial class NarrativeRevard
{
    public int Id { get; set; }

    public int NarrativeId { get; set; }

    public int RevardId { get; set; }

    public DateTime DateRevarded { get; set; }

    public virtual Narrative Narrative { get; set; } = null!;

    public virtual Revard Revard { get; set; } = null!;
}
