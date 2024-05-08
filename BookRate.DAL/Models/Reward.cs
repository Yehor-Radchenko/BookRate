using System;
using System.Collections.Generic;

namespace BookRate.DAL.Models;

public partial class Reward
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Website { get; set; }

    public virtual ICollection<NarrativeReward> NarrativeRewards { get; set; } = new List<NarrativeReward>();
}
