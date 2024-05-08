using System;
using System.Collections.Generic;

namespace BookRate.DAL.Models;

public partial class Contributor
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public DateTime? BirthDate { get; set; }

    public DateTime? DeathDate { get; set; }

    public string Biography { get; set; } = null!;

    public string BirthPlace { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public virtual ICollection<Narrative> Narratives { get; set; } = new List<Narrative>();

    public virtual IEnumerable<Role> Roles { get; set; } = new List<Role>();

    public virtual IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
}
