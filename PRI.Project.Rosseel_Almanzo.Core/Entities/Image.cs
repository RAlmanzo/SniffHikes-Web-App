using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int? UserId { get; set; }
        public string File { get; set; }
        public Route Route { get; set; }
        public int? RouteId { get; set; }
        public Event Event { get; set; }
        public int? EventId { get; set; }
    }
}
