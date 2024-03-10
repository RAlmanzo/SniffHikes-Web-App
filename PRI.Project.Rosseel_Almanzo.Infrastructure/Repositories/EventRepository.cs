using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Infrastructure.Repositories
{
    public class EventRepository : BaseRepository<Event>
    {
        public EventRepository(SniffHikesDbContext context, ILogger<BaseRepository<Event>> logger) 
            : base(context, logger)
        {
        }

        public override IQueryable<Event> GetAll()
        {
            return _targetTable
                .Include(e => e.Address)
                .Include(e => e.Comments)
                .Include(e => e.Users)
                .Include(e => e.Images)
                .AsQueryable();
        }

        public override Task<IEnumerable<Event>> GetAllAsync()
        {
            return base.GetAllAsync();
        }

        public override Task<Event> GetByIdAsync(int id)
        {
            return base.GetByIdAsync(id);
        }
    }
}
