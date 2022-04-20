using General.Models;
using General.Models.Requests;
using General.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CustomerSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        public AuthController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest loginUser)
        {
            // My application logic to validate the user
            // returns a user entity with Roles collection
            var user = await _userManager.FindByNameAsync(loginUser.UserName);
            var roles = await _userManager.GetRolesAsync(user);
            if (user == null)
                return BadRequest("Invalid email and password or user is not admin");

            var claims = new List<Claim>();
            claims.Add(new Claim("username", loginUser.UserName));

            // Add roles as multiple claims
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // create a new token with token helper and add our claim
            // from `Westwind.AspNetCore`  NuGet Package
            var token = JwtHelper.GetJwtToken(
                loginUser.UserName,
                _configuration["JWT:Key"],
                _configuration["JWT:Issuer"],
                _configuration["JWT:Audience"],
                TimeSpan.FromMinutes(20),
                claims.ToArray());

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expires = token.ValidTo
            });
        }
    }
}
