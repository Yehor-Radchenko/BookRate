using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.Models
{
    public class NarrativeContributorRole
    {
        public int NarrativeId { get; set; }
        public Narrative Narrative { get; set; }

        public int ContributorRoleId { get; set; }
        public ContributorRole ContributorRole { get; set; }
    }
}
