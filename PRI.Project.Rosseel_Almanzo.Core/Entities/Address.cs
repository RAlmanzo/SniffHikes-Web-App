namespace PRI.Project.Rosseel_Almanzo.Core.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        //public User User { get; set; }
        //public int? UserId { get; set; }
        //public Route Route { get; set; }
        //public int? RouteId { get; set; }
        //public Event Event { get; set; }
        //public int? EventId { get; set; }
    }
}