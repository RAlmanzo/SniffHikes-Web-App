using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Rosseel_Almanzo.Api.Dtos
{
    public class ImageRequestDto
    {
        public IFormFile Image { get; set; }
    }
}
