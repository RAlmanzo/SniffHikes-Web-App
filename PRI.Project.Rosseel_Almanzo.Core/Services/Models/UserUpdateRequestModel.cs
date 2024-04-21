using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Services.Models
{
    public class UserUpdateRequestModel : UserCreateRequestModel
    {
        public string Id { get; set; }
    }
}
