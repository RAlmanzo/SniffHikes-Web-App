using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Rosseel_Almanzo.Api.Dtos
{
    public class RouteRequestDto
    {
        [Required(ErrorMessage = "Title missing")]
        [StringLength(50, ErrorMessage = "Title is too long")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description is too long")]
        public string Description { get; set; }
        public int OrganizerId { get; set; }
        public AddressRequestDto Address { get; set; }
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
