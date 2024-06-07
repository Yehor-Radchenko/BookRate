using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.DTO.NarrativeRevard
{
    public class NarrativeRewardDto
    {
        public int NarrativeId { get; set; }

        public int RewardId { get; set; }

        public DateTime DateRewarded { get; set; }
    }
}
