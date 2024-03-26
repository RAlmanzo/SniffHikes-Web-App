using PRI.Project.Rosseel_Almanzo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Services.Models
{
    public class EventCreateRequestModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int OrganizerId { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateCreated { get; set; }    
    }
}
