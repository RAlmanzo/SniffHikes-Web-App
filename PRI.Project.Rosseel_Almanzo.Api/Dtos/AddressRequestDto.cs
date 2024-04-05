using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Rosseel_Almanzo.Api.Dtos
{
    public class AddressRequestDto
    {
        [StringLength(50, ErrorMessage = "Country name is too long")]
        public string Street { get; set; }
        [StringLength(50, ErrorMessage = "Country name is too long")]
        public string City { get; set; }
        [StringLength(50, ErrorMessage = "Country name is too long")]
        public string State { get; set; }
        [StringLength(50, ErrorMessage = "Country name is too long")]
        public string Country { get; set; }
    }
}
