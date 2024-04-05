using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRI.Project.Rosseel_Almanzo.Api.Dtos;
using PRI.Project.Rosseel_Almanzo.Api.Extensions;
using PRI.Project.Rosseel_Almanzo.Api.Services.Interfaces;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services;
using PRI.Project.Rosseel_Almanzo.Core.Services;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;

namespace PRI.Project.Rosseel_Almanzo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<EventsController> _logger;
        private readonly IFileService _fileService;

        public UsersController(IUserService userService, IWebHostEnvironment webHostEnvironment, ILogger<EventsController> logger, IFileService fileService)
        {
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get all events
            var result = await _userService.GetAllAsync();
            //check if result is succes
            if (result.Success)
            {
                return Ok(result.Value.MapToDto());
            }
            return NotFound(result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            //get the record
            var result = await _userService.GetByIdAsync(id);
            //check if result is succes
            if (result.Success)
            {
                return Ok(result.Value.MapToDto());
            }
            return NotFound(result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm]UserRequestDto userRequestDto)
        {
            //check if image is given
            var filename = "";
            if (userRequestDto.Image != null)
            {
                filename = await _fileService.StoreFile<User>(userRequestDto.Image);
            }

            ////check if dogs is null
            //if (userRequestDto.Dogs == null)
            //{
            //    userRequestDto.Dogs = new List<BaseDogRequestDto>();
            //}

            var result = await _userService.CreateUserAsync(
                new UserCreateRequestModel
                {
                    FirstName = userRequestDto.FirstName,
                    LastName = userRequestDto.LastName,
                    DateOfBirth = userRequestDto.DateOfBirth,
                    Gender = userRequestDto.Gender,
                    Email = userRequestDto.Email,
                    Password = userRequestDto.Password,
                    Image = filename,
                    Address = new Address
                    {
                        Street = userRequestDto.Address.Street,
                        City = userRequestDto.Address.City,
                        State = userRequestDto.Address.State,
                        Country = userRequestDto.Address.Country,
                    },
                    //Dogs = userRequestDto.Dogs.Select(d => new Dog
                    //{
                    //    Name = d.Value,
                    //    Race = d.Race,
                    //    Gender = d.Gender,
                    //    DateOfBirth = d.DateOfBirth,
                    //    Image = d.Image,
                    //}),
                });

            if (result.Success)
            {
                return CreatedAtAction(nameof(Get), new { ID = result.Value.Id }, result.Value
                    .MapToDto());
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return BadRequest(ModelState.Values);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userResult = await _userService.GetByIdAsync(id);

            if (!userResult.Success)
            {
                return NotFound("User not found!");
            }

            //if (!await _userService.CheckIfExistsAsync(id))
            //{
            //    return NotFound("User not found!");
            //}
            if(!string.IsNullOrWhiteSpace(userResult.Value.Image))
            {
                if (!_fileService.DeleteFile<User>(userResult.Value.Image))
                {
                    ModelState.AddModelError("", "Image not found");
                }
            }
   
            var result = await _userService.DeleteUserAsync(id);
            if (result.Success)
            {
                return Ok();
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return BadRequest(ModelState.Values);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm]UserUpdateRequestDto userUpdateRequestDto)
        {
            //check if user exists
            if (!await _userService.CheckIfExistsAsync(userUpdateRequestDto.Id))
            {
                return NotFound("Event not found!");
            }

            //check if new user image
            var filename = "";
            if (userUpdateRequestDto.Image != null)
            {
                //get user current image
                var user = await _userService.GetByIdAsync(userUpdateRequestDto.Id);
                //delete current image
                if (!string.IsNullOrWhiteSpace(user.Value.Image))
                {
                    if (!_fileService.DeleteFile<User>(user.Value.Image))
                    {
                        ModelState.AddModelError("", "Image not found");
                    }
                }
                //save new image
                filename = await _fileService.StoreFile<User>(userUpdateRequestDto.Image);
            }

            var result = await _userService.UpdateUserAsync(
                new UserUpdateRequestModel
                {
                    Id = userUpdateRequestDto.Id,
                    FirstName = userUpdateRequestDto.FirstName,
                    LastName = userUpdateRequestDto.LastName,
                    DateOfBirth = userUpdateRequestDto.DateOfBirth,
                    Gender = userUpdateRequestDto.Gender,
                    Email = userUpdateRequestDto.Email,
                    Password = userUpdateRequestDto.Password,
                    Image = filename,
                    Address = new Address
                    {
                        Street = userUpdateRequestDto.Address.Street,
                        City = userUpdateRequestDto.Address.City,
                        State = userUpdateRequestDto.Address.State,
                        Country = userUpdateRequestDto.Address.Country,
                    },
                    //Dogs = userRequestDto.Dogs.Select(d => new Dog
                    //{
                    //    Name = d.Value,
                    //    Race = d.Race,
                    //    Gender = d.Gender,
                    //    DateOfBirth = d.DateOfBirth,
                    //    Image = d.Image,
                    //}),
                });
            if (result.Success)
            {
                return Ok();
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return BadRequest(ModelState.Values);
        }
    }
}
