namespace PRI.Project.Rosseel_Almanzo.Api.Dtos
{
    public class EventsGetResponseDto : BaseDto
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateCreated { get; set; }
        public BaseUserDto Orginazer { get; set; }
        public BaseDto Address { get; set; }
        public IEnumerable<BaseDto> Images { get; set; }
        public IEnumerable<BaseDto> Comments { get; set; }
        public IEnumerable<BaseUserDto> Users { get; set; }
    }
}
