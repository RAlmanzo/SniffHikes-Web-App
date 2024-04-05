using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Rosseel_Almanzo.Api.Dtos
{
    public class AddressRequestDto
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Required(ErrorMessage = "Country is required")]
        [StringLength(50, ErrorMessage = "Country name is too long")]
        public string Country { get; set; }
    }
}
