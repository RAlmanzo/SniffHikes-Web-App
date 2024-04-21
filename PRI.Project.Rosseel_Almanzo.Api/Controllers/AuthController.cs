using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PRI.Project.Rosseel_Almanzo.Api.Dtos;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace PRI.Project.Rosseel_Almanzo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AuthLoginRequestDto authLoginRequestDto)
        {
            //authenticate the user
            var result = await _signInManager.PasswordSignInAsync
                (authLoginRequestDto.UserName, authLoginRequestDto.Password, false, false);
            if (!result.Succeeded)//wrong credentials
            {
                ModelState.AddModelError("", "Wrong credentials!");
                return Unauthorized(ModelState.Values);
            }
            //get the user
            var user = await _userManager.FindByNameAsync(authLoginRequestDto.UserName);
            //get the claims
            var claims = await _userManager.GetClaimsAsync(user);
            //generate the token
            //set the token parameters
            var issuer = _configuration.GetValue<string>("JWTConfiguration:Issuer");
            var audience = _configuration.GetValue<string>("JWTConfiguration:Audience");
            var expiration = DateTime.Now.AddDays(_configuration.GetValue<int>("JWTConfiguration:ExpirationInDays"));
            var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWTConfiguration:SecretKey"));
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            var signinCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //token
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                notBefore: DateTime.Now,
                expires: expiration,
                claims: claims,
                signingCredentials: signinCredentials
                );
            //serialize token
            var serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
            //return the token
            return Ok(new AuthLoginResponseDto { Token = serializedToken });
        }
    }
}
