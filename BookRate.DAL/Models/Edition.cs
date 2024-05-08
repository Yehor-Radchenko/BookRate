using System;
using System.Collections.Generic;

namespace BookRate.DAL.Models;

public partial class Edition
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Website { get; set; }

    public virtual ICollection<BookEdition> BookEditions { get; set; } = new List<BookEdition>();
}
