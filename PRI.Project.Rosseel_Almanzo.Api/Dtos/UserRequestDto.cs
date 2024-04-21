using Microsoft.AspNetCore.Mvc;
using PRI.Project.Rosseel_Almanzo.Api.Validators;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Rosseel_Almanzo.Api.Dtos
{
    public class UserRequestDto
    {
        [Required(ErrorMessage = "Firstname is required")]
        [StringLength(50, ErrorMessage = "Firstname is too long")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        [StringLength(50, ErrorMessage = "Lastname is too long")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [UserDateValidator(ErrorMessage = "Birthday cant be in de future")]
        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public AddressRequestDto Address { get; set; }
        public IFormFile Image { get; set; }
    }
}
