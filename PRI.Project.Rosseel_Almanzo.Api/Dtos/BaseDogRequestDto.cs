using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Rosseel_Almanzo.Api.Dtos
{
    public class BaseDogRequestDto
    {
        [Required(ErrorMessage = "Dog name is required")]
        [StringLength(50, ErrorMessage = "Dog name is too long")]
        public string Value { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Image { get; set; }
    }
}
