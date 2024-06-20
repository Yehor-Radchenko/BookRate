using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRate.DAL.Models;


public  class Review
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title
    {
        get => _title;
        set => _title = value?.Trim();
    }

    private string _title = null!;

    [Required(ErrorMessage = "Text is required.")]
    public string Text
    {
        get => _text;
        set => _text = value?.Trim();
    }

    private string _text = null!;

    [Required]
    [Column(TypeName = "smalldatetime")]
    public DateTime DatePosted { get; set; }

    [DataType(DataType.Date)]
    public DateTime? StartReadDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? EndReadDate { get; set; }

    public virtual ICollection<Commentary> Commentaries { get; set; } = new List<Commentary>();

    public virtual ICollection<ReviewLike> ReviewLikes { get; set; } = new List<ReviewLike>();

    [Column(TypeName = "timestamp")]
    public byte[] Timestamp { get; set; }

    public int RateId { get; set; }
    public virtual Rate Rate { get; set; } = null!;

    public int BookId { get; set; }
    public Book Book { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
    
}
