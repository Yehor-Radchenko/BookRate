﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.DTO.Review
{
    public class ReviewDto
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime DatePosted { get; set; }

        public DateTime? StartReadDate { get; set; }

        public DateTime? EndReadDate { get; set; }

        public int RateId { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }

        [Range(1, 5)]
        public int RateStarts { get; set; }

    }
}
