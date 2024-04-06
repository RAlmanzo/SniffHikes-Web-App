using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Rosseel_Almanzo.Api.Dtos
{
    public class AddressRequestDto
    {
        [Required(ErrorMessage = "Street is required")]
        [StringLength(50, ErrorMessage = "Street name is too long")]
        public string Street { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(50, ErrorMessage = "City name is too long")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(50, ErrorMessage = "State name is too long")]
        public string State { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(50, ErrorMessage = "Country name is too long")]
        public string Country { get; set; }
    }
}
