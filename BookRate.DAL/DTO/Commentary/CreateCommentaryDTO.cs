﻿namespace BookRate.DAL.DTO.Commentary
{
    public class CreateCommentaryDTO
    {
        public int UserId { get; set; }

        public int ReviewId { get; set; }

        public string Text { get; set; }

        public DateTime DateCommented { get; set; }
    }
}
