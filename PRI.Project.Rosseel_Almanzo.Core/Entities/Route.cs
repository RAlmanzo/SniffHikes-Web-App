namespace PRI.Project.Rosseel_Almanzo.Core.Entities
{
    public class Route : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public ICollection<Image> Images { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}