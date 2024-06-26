﻿using BookRate.BLL.ViewModels.Genre;
using BookRate.BLL.ViewModels.Role;
using BookRate.DAL.Models;

namespace BookRate.BLL.ViewModels.Contributor
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

        public virtual IEnumerable<RoleViewModel> Roles { get; set; }

        public virtual IEnumerable<GenreListModel> Genres { get; set; }

        public string? PhotoBase64 { get; set; }
    }
}
