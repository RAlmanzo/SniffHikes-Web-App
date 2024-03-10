using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Repositories;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Services
{
    public class EventService : IEventService
    {
        public Task<ResultModel<Event>> DeleteRecordAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<IEnumerable<Event>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<Event>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
