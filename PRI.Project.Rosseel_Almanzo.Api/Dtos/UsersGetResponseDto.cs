using PRI.Project.Rosseel_Almanzo.Core.Entities;

namespace PRI.Project.Rosseel_Almanzo.Api.Dtos
{
    public class UsersGetResponseDto : BaseDto
    {
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public BaseDto Address { get; set; }
        public IEnumerable<BaseDto> Dogs { get; set; }
        public string Image { get; set; }
    }
}
