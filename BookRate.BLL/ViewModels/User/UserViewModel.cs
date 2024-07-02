using BookRate.BLL.ViewModels.Role;
using Microsoft.AspNetCore.Http;

namespace BookRate.BLL.ViewModels.User
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string? Patronymic { get; set; }

        public IFormFile? Photo { get; set; }

        public string? Interests { get; set; }

        public IEnumerable<int> RolesId { get; set; } = null!;

        public int CountCommentaries { get; set; }

        public int CountReviews { get; set; }
    }
}
