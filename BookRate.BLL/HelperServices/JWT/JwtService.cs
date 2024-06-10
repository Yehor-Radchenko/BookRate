using BookRate.BLL.ViewModels.Role;
using BookRate.BLL.ViewModels.User;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using User = BookRate.DAL.Models.User;

namespace BookRate.BLL.HelperServices
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Email", user.Email),
                new Claim("UserName", user.Username),
                new Claim("LastName", user.LastName),
                new Claim("FirstName", user.FirstName),
            };

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim("Role", role.Name));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));

            var sign = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            claims: claims,
            issuer: "localhost",
            audience: "localhost",
            signingCredentials: sign,
            expires: DateTime.Now.AddDays(7));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
