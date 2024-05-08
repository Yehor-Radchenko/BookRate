using System;
using System.Collections.Generic;

namespace BookRate.DAL.Models;

public partial class Serie
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
