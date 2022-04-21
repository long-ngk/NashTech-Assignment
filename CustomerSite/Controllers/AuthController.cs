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
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
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
            var user = await _userManager.FindByEmailAsync(loginUser.Email);
            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, false);
            if (!result.Succeeded)
                return NotFound("Invalid email or password!");

            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Contains(SD.Role_Admin))
                return NotFound("User is not admin!");

            var claims = new List<Claim>();
            claims.Add(new Claim("email", loginUser.Email));

            // Add roles as multiple claims
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // create a new token with token helper and add our claim
            // from `Westwind.AspNetCore`  NuGet Package
            var token = JwtHelper.GetJwtToken(
                loginUser.Email,
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
