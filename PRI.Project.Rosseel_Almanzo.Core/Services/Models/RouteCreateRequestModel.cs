using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Services.Models
{
    public class RouteCreateRequestModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string OrganizerId { get; set; }
        public DateTime DateCreated { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
