using PRI.Project.Rosseel_Almanzo.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Rosseel_Almanzo.Api.Dtos
{
    public class UserRequestDto
    {
        [Required(ErrorMessage = "Firstname is required")]
        [StringLength(50, ErrorMessage = "Firstname is to long")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        [StringLength(50, ErrorMessage = "Lastname is to long")]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
        public IEnumerable<int> CommentIds { get; set; }
        public IEnumerable<int> OrganizedEventIds { get; set; }
        public IEnumerable<int> AttendingEventIds { get; set; }
        public IEnumerable<int> ImageIds { get; set; }
        //public IEnumerable<Dog> Dogs { get; set; }
    }
}
