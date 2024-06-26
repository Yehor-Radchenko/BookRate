﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.DTO.Contributor
{
    public class ContributorDto
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string? Patronymic { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? DeathDate { get; set; }

        public string? Biography { get; set; }

        public string? BirthPlace { get; set; }

        public virtual IEnumerable<int> RolesId { get; set; }

        public virtual IEnumerable<int>? GenresId { get; set; }

        public IFormFile? Photo { get; set; }
    }
}
