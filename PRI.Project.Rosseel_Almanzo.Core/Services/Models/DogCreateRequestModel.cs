using PRI.Project.Rosseel_Almanzo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Services.Models
{
    public class DogCreateRequestModel
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }
    }
}
