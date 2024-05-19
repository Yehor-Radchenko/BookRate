using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookRate.DAL.Models;

public partial class Book
{
    public int Id { get; set; }

    public int? SerieId { get; set; }

    [Required(ErrorMessage = "First published date is required.")]
    [DataType(DataType.Date)]
    public DateTime FirstPublished { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; }

    public virtual ICollection<BookEdition> BookEditions { get; set; } = new List <BookEdition>();

    public virtual ICollection<Rate>? Rates { get; set; } = new List <Rate>();

    public virtual ICollection<Review>? Reviews { get; set; } = new List <Review>();

    public virtual Serie? Serie { get; set; }

    public virtual ICollection<Narrative> Narratives { get; set; } = new List <Narrative>();

    public virtual ICollection<Shelf> Shelves { get; set; } = new List <Shelf>();
}
