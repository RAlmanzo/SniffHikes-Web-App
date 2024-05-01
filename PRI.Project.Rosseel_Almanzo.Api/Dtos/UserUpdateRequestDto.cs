using PRI.Project.Rosseel_Almanzo.Api.Validators;
using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Rosseel_Almanzo.Api.Dtos
{
    public class UserUpdateRequestDto : UserRequestDto
    {
        [Required(ErrorMessage = "Id required")]
        public string Id { get; set; }
    }
}
