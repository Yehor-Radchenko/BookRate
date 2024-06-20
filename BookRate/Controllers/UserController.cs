using BookRate.BLL.Services;
using BookRate.DAL.DTO.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        
        [Authorize(policy: "AdminPolicy")]
        [HttpGet("users-list")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok("user:1");
        }
        
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("profile-info/{id}")]
        public async Task<IActionResult> ProfileInfo(int id)
        {
            var result = await _userService.GetInfoAboutProfileAsync(id);
            return Ok(result);
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUser(UserDto user)
        {
            var result = await _userService.AddAsync(user);
            return Ok(result);
        }

        [HttpPost("login-user")]
        public async Task<IActionResult> LoginUser(LoginDto loginDto)
        {
            var result = await _userService.LoginAsync(loginDto);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("Token", result);
            return Ok(result);
        }

        [Authorize(policy: "AdminPolicy", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("ban-user/{id}")]
        public async Task<IActionResult> BanUser(int id)
        {
            var result = await _userService.BanUserAsync(id);
            return Ok(result);
        }

        [Authorize(policy: "AdminPolicy", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("unban-user/{id}")]
        public async Task<IActionResult> UnbanUser(int id)
        {
            var result = await _userService.UnbanUserAsync(id);
            return Ok(result);
        }

        [HttpPut("update-user/{email}")]
        public async Task<IActionResult> UpdateUser(string email, UpdateUserDto dto)
        {
            var result = await _userService.UpdateAsync(email, dto);
            return Ok(result);
        }
        
        
    }
    
}
