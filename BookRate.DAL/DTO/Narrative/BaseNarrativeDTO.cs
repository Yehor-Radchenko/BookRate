using BookRate.DAL.DTO.NarrativeRevard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.DTO.Narrative
{
    public abstract class BaseNarrativeDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string? OriginalTitle { get; set; }

        public string ThreeLetterIsolanguageName { get; set; }

        public virtual IEnumerable<int> ContributorRoleIds { get; set; }

        public virtual IEnumerable<int> GenresId { get; set; }

        public virtual IEnumerable<int>? SettingsId { get; set; }

        public virtual IEnumerable<CreateNarrativeRewardDTO>? NarrativeRewards { get; set; } = null;
    }
}
