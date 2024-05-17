using System;
using System.Collections.Generic;

namespace BookRate.DAL.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<ContributorRole> ContributorRoles { get; set; }
}
