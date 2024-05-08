using System;
using System.Collections.Generic;

namespace BookRate.DAL.Models;

public partial class Narrative
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? OriginalTitle { get; set; }

    public string ThreeLetterIsolanguageName { get; set; } = null!;

    public virtual ICollection<NarrativeReward> NarrativeRewards { get; set; } = new List<NarrativeReward>();

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual ICollection<Contributor> Contributors { get; set; } = new List<Contributor>();

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();

    public virtual ICollection<Setting> Settings { get; set; } = new List<Setting>();
}
