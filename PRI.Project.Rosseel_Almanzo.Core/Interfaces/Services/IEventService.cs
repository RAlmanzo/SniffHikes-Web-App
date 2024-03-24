using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services
{
    public interface IEventService
    {
        Task<ResultModel<IEnumerable<Event>>> GetAllAsync();
        Task<ResultModel<Event>> GetByIdAsync(int id);
        Task<ResultModel<Event>> CreateEventAsync(EventCreateRequestModel eventCreateRequestModel);
        //Task<ResultModel<Event>> UpdateRecordAsync(EventUpdateRequestModel eventUpdateRequestModel);
        Task<ResultModel<Event>> DeleteEventAsync(int id);
    }
}
