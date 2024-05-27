using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookRate.DAL.Models;

public partial class Role
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Role name is required.")]
    [StringLength(100, ErrorMessage = "Role name cannot exceed 100 characters.")]
    [RegularExpression(@"^[A-Za-zА-Яа-яЁёЇїІіЄєҐґ]+(?:\s[A-Za-zА-Яа-яЁёЇїІіЄєҐґ]+)*$",
        ErrorMessage = "Role name must consist of words separated by a single space.")]
    public string Name { get; set; }

    public virtual ICollection<ContributorRole> ContributorRoles { get; set; }
}
