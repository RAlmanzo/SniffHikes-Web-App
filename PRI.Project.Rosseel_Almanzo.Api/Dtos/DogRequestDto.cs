using Microsoft.AspNetCore.Mvc;
using PRI.Project.Rosseel_Almanzo.Api.Validators;
using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Rosseel_Almanzo.Api.Dtos
{
    public class DogRequestDto
    {
        [Required(ErrorMessage = "Dog name is required")]
        [StringLength(50, ErrorMessage = "Dog name is too long")]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [UserDateValidator(ErrorMessage = "Birthday cant be in de future")]
        public DateTime DateOfBirth { get; set; }
        public IFormFile Image { get; set; }
    }
}
