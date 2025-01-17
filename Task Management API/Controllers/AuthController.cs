using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Task_Management_API.Models;

namespace Task_Management_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration configuration;
        private List<LoginModel> users;
        public AuthController(IConfiguration config)
        {
            configuration = config;

        }
        [HttpPost("token")]
        public IActionResult GenerateToken([FromBody] LoginModel login)
        {
            users = configuration.GetSection("Users").Get<List<LoginModel>>();
            bool validated = users.Any(p => p.Username == login.Username && p.Password == login.Password);
            if (validated)
            {
                var claims = new[]
                {
                     new Claim(JwtRegisteredClaimNames.Sub, login.Username),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("SecretKey").Value));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
               issuer: configuration.GetSection("domain").Value,
               audience: configuration.GetSection("domain").Value,
               claims: claims,
               expires: DateTime.Now.AddMinutes(30),
               signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return Unauthorized();
        }
    }
}
