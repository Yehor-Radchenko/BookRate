using System.Text.Json.Serialization;

namespace BookRate.DAL.DTO.User
{
    public  class UpdateUserDto
    {
        
        public string Username { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string? Patronymic { get; set; }

        public string? Interests { get; set; }

        public ICollection<int> Roles { get; set; }
    }
}
