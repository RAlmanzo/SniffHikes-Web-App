namespace PRI.Project.Rosseel_Almanzo.Core.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public User User { get; set; }
        public int? UserId { get; set; }
        public Route Route { get; set; }
        public int? RouteId { get; set; }
        public Event Event { get; set; }
        public int? EventId { get; set; }
    }
}