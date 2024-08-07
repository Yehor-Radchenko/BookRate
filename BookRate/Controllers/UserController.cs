
using BookRate.BLL.Services;
using BookRate.DAL.DTO.Restrict;
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


        public UserController()
        {

        }

        [Authorize(policy: "AdminPolicy")]
        [HttpGet("users-list")]
        public async Task<IActionResult> GetUsersAsync()
        {
            var result = await _userService.GetUsersAsync();
            return Ok(result);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("profile-info/{id}")]
        public async Task<IActionResult> ProfileInfoAsync(int id)
        {
            if (id <= 0)
                return BadRequest();

            var result = await _userService.GetInfoAboutProfileAsync(id);
            return Ok(result);
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUserAsync(UserDto user)
        {
            var result = await _userService.AddAsync(user);

            if (!result)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost("login-user")]
        public async Task<IActionResult> LoginUserAsync(LoginDto loginDto)
        {
         
            var result = await _userService.LoginAsync(loginDto);
            // _httpContextAccessor.HttpContext.Response.Cookies.Append("Token", result);

            return Ok(result);
        }

        [Authorize(policy: "AdminPolicy", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("ban-user")]
        public async Task<IActionResult> BanUser(RestrictDto restrictDto)
        {
            var result = await _userService.BanUserAsync(restrictDto);
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
