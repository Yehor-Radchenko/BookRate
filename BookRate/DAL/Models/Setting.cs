using System;
using System.Collections.Generic;

namespace BookRate.DAL.Models;

public partial class Setting
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Narrative> Narratives { get; set; } = new List<Narrative>();
}
