using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PRI.Project.Rosseel_Almanzo.Api.Dtos;
using PRI.Project.Rosseel_Almanzo.Api.Services.Interfaces;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
        private readonly IUserService _userService;
        private readonly IFileService _fileService;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, IUserService userService, IFileService fileService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _userService = userService;
            _fileService = fileService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AuthLoginRequestDto authLoginRequestDto)
        {
            //authenticate the user
            var result = await _userService.LoginUserAsync(authLoginRequestDto.UserName, authLoginRequestDto.Password);
            if (!result.Success)
            {
                //add to the modelstate
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return BadRequest(ModelState.Values);
            }

            return Ok(result.Value);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm]AuthRegisterRequestDto authRegisterRequestDto)
        {
            //create the user
            //check if image is given
            var filename = "";
            if (authRegisterRequestDto.Image != null)
            {
                filename = await _fileService.StoreFile<User>(authRegisterRequestDto.Image);
            }

            var result = await _userService.CreateUserAsync(
                new UserCreateRequestModel
                {
                    FirstName = authRegisterRequestDto.FirstName,
                    LastName = authRegisterRequestDto.LastName,
                    DateOfBirth = authRegisterRequestDto.DateOfBirth,
                    Gender = authRegisterRequestDto.Gender,
                    Email = authRegisterRequestDto.Email,
                    Password = authRegisterRequestDto.Password,
                    Image = filename,
                    Address = new Address
                    {
                        Street = authRegisterRequestDto.Address.Street,
                        City = authRegisterRequestDto.Address.City,
                        State = authRegisterRequestDto.Address.State,
                        Country = authRegisterRequestDto.Address.Country,
                    },

                });

            if (!result.Success)
            {
                //add to the modelstate
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return BadRequest(ModelState.Values);
            }

            //call the emailservice?????
            return Ok("Registered");
        }
    }
}
