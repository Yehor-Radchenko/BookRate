﻿namespace BookRate.DAL.DTO.Rate
{
    public class UpdateRateDTO
    {
        public int UserId { get; set; }

        public int BookId { get; set; }

        public int StarsRate { get; set; }

        public DateTime DateRated { get; set; }
    }
}
