using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.DTO.User
{
    public  class UserDto
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string? ConfirmPassword { get; set; }

        public string Username { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string? Patronymic { get; set; }

        public IFormFile? Photo { get; set; }

        public string? Interests { get; set; }

        public IEnumerable<int> RolesId { get; set; }
    }
}
