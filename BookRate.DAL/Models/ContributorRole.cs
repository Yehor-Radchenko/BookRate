using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.Models
{
    public class ContributorRole
    {
        public int Id { get; set; }

        public int ContributorId { get; set; }
        public Contributor Contributor { get; set; } = null!;

        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;

        public virtual ICollection<NarrativeContributorRole> NarrativeContributorRoles { get; set; } = null!;
    }
}
