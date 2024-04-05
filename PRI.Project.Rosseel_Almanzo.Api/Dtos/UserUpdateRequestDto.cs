using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Rosseel_Almanzo.Api.Dtos
{
    public class UserUpdateRequestDto
    {
        [Required(ErrorMessage = "Id required")]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Firstname is too long")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Lastname is too long")]
        public string LastName { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        public string Password { get; set; }

        public AddressRequestDto Address { get; set; }
        //public IEnumerable<BaseDogRequestDto> Dogs { get; set; }
        public IFormFile Image { get; set; }
    }
}
