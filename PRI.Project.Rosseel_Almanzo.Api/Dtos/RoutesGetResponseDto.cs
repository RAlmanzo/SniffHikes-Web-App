namespace PRI.Project.Rosseel_Almanzo.Api.Dtos
{
    public class RoutesGetResponseDto : BaseDto
    {
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public BaseDto Address { get; set; }
        public BaseUserDto Orginazer { get; set; }
        public IEnumerable<BaseDto> Images { get; set; }
        public IEnumerable<BaseDto> Comments { get; set; }
    }
}
