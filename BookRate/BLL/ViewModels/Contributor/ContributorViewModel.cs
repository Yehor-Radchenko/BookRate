﻿using BookRate.DAL.Models;

namespace BookRate.BLL.ViewModels
{
    public class ContributorViewModel
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string? Patronymic { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? DeathDate { get; set; }

        public string? Biography { get; set; }

        public string? BirthPlace { get; set; }

        public byte[]? Photo { get; set; }

        public virtual IEnumerable<RoleViewModel> Roles { get; set; }
    }
}
