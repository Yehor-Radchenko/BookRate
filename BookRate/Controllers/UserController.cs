using BookRate.BLL.Services;
using BookRate.BLL.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace BookRate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(UserService userService,
            IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUser(User user)
        {
            var result = await _userService.AddAsync(user);
            return Ok(result);
        }

        [HttpPost("login-user")]
        public async Task<IActionResult> LoginUser(LoginViewModel loginViewModel)
        {
            var result = await _userService.LoginAsync(loginViewModel);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("Token", result);
            return Ok(result);
        }
    }

}
