using System;
using System.Collections.Generic;

namespace BookRate.DAL.Models;

public partial class Book
{
    public int Id { get; set; }

    public int? SerieId { get; set; }

    public DateTime FirstPublished { get; set; }

    public string Title { get; set; }

    public virtual ICollection<BookEdition> BookEditions { get; set; }

    public virtual ICollection<Rate>? Rates { get; set; }

    public virtual ICollection<Review>? Reviews { get; set; }

    public virtual Serie? Serie { get; set; }

    public virtual ICollection<Narrative> Narratives { get; set; }

    public virtual ICollection<Shelf> Shelves { get; set; }
}
