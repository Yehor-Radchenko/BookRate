﻿namespace BookRate.DAL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Login { get; set; } 

        public string Password { get; set; } 

        public string LastName { get; set; } 

        public string FirstName { get; set; } 

        public string? Patronymic { get; set; }

        public byte[]? Photo { get; set; }

        public string? Interests { get; set; }
    }
}
