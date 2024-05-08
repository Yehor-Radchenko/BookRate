using System;
using System.Collections.Generic;

namespace BookRate.DAL.Models;

public partial class BookEdition
{
    public int Id { get; set; }

    public int CoverType { get; set; }

    public int PagesCount { get; set; }

    public DateTime EditionDate { get; set; }

    public string Ibsn { get; set; } = null!;

    public int BookId { get; set; }

    public int EditionId { get; set; }

    public byte[] Photo { get; set; } = null!;

    public virtual Book Book { get; set; } = null!;

    public virtual Edition Edition { get; set; } = null!;
}
