using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.DTO.ReviewLike
{
    public class RemoveLikeDto
    {
        public int ReviewId { get; init; }

        public int  UserId { get; init; }   
    }
}
