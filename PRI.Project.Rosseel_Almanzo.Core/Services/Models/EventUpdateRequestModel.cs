using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Services.Models
{
    public class EventUpdateRequestModel : EventCreateRequestModel
    {
        public int Id { get; set; }
        //public IEnumerable<int> ImageIds { get; set; }
    }
}
