
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace PRI.Project.Rosseel_Almanzo.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Dog> Dogs { get; set; }
        public ICollection<Route> Routes { get; set; }
        public ICollection<Event> OrganizedEvents { get; set; }
        public ICollection<Event> AttendingEvents { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
