namespace BookRate.DAL.DTO.User
{
    public class UpdateUserDTO
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string? Patronymic { get; set; }

        public byte[]? Photo { get; set; }

        public string? Interests { get; set; }
    }
}
