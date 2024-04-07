using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Rosseel_Almanzo.Api.Dtos
{
    public class DogUpdateRequestDto : DogRequestDto
    {
        [Required(ErrorMessage = "Id required")]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}
