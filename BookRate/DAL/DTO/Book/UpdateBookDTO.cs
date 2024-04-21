﻿namespace BookRate.DAL.DTO
{
    public class UpdateBookDTO
    {
        public int Id { get; set; }

        public int? SerieId { get; set; }

        public string Title { get; set; }

        public DateTime FirstPublished { get; set; }

        public virtual IEnumerable<int> NarrativesId { get; set; }
    }
}