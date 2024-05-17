using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.BLL.ViewModels.Reward
{
    public class NarrativeRewardViewModel
    {
        public int Id { get; set; }

        public int NarrativeId { get; set; }

        public int RewardId { get; set; }

        public string Name { get; set; }

        public DateTime DateRewarded { get; set; }
    }
}
