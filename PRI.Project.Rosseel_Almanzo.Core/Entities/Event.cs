namespace PRI.Project.Rosseel_Almanzo.Core.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Address Address { get; set; }
        public ICollection<Image> Images { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public User Organizer { get; set; }
        public int OrganizerId { get; set; }
        public ICollection<User> Users { get; set; }
    }
}