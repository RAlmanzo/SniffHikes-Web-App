using Microsoft.AspNetCore.Mvc;
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
        public DateTime DateOfBirth { get; set; }
        public IFormFile Image { get; set; }
    }
}
