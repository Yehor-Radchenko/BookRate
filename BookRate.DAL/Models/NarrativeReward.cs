using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRate.DAL.Models;

public partial class NarrativeReward
{
    public int Id { get; set; }

    public int NarrativeId { get; set; }

    public int RewardId { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime DateRewarded { get; set; }

    public virtual Narrative Narrative { get; set; } = null!;

    public virtual Reward Reward { get; set; } = null!;
}
