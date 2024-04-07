using PRI.Project.Rosseel_Almanzo.Api.Validators;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Rosseel_Almanzo.Api.Dtos
{
    public class EventRequestDto
    {
        [Required(ErrorMessage = "Title missing")]
        [StringLength(50, ErrorMessage = "Title is too long")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description is too long")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required,can be 0")]
        [Range(0.0, int.MaxValue)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Date of event is required")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [EventDateValidator(ErrorMessage = "Date must be in de future")]
        public DateTime Date { get; set; }
        public int OrganizerId { get; set; }
        public AddressRequestDto Address { get; set; }
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
