using PRI.Project.Rosseel_Almanzo.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Rosseel_Almanzo.Api.Dtos
{
    public class EventRequestDto
    {
        [Required(ErrorMessage = "Title missing")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(0.0, int.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public DateTime DateCreated { get; set; }
        [Required]
        public int OrganizerId { get; set; }
        [Required]
        public Address Address { get; set; }
        //public IEnumerable<int> ImageIds { get; set; }    
        //public IEnumerable<int> CommentIds { get; set; }     
        //public IEnumerable<int> AttendingUserIds { get; set; }
    }
}
