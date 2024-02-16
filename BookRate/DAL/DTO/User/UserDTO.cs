namespace BookRate.DAL.DTO.User
{
    public class UserDTO
    {
        public string Login { get; set; } 

        public string Password { get; set; } 

        public string LastName { get; set; } 

        public string FirstName { get; set; } 

        public string? Patronymic { get; set; }

        public byte[]? Photo { get; set; }

        public string? Interests { get; set; }
    }
}
