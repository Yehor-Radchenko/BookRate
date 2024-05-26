using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.DTO.Reward
{
    public abstract class BaseRewardDTO
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Website { get; set; }
    }
}
