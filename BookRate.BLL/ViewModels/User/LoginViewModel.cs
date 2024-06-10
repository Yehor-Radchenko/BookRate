using System.ComponentModel.DataAnnotations;

namespace BookRate.BLL.ViewModels.User
{
    public class LoginViewModel
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
