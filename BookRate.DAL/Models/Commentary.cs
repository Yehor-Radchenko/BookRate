namespace BookRate.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Commentary
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Text is required.")]
        public string Text { get; set; } = null!;

        [Required(ErrorMessage = "Date commented is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DateCommented { get; set; }

        public int UserId { get; set; }

        public int ReviewId { get; set; }

        public virtual ICollection<CommentaryLike> CommentaryLikes { get; set; } = new List<CommentaryLike>();

        public virtual Review Review { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
