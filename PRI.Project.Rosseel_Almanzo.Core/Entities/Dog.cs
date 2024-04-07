namespace PRI.Project.Rosseel_Almanzo.Core.Entities
{
    public class Dog : BaseEntity
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Image { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}