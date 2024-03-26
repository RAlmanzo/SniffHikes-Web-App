using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Repositories;
using PRI.Project.Rosseel_Almanzo.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Infrastructure.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(SniffHikesDbContext context, ILogger<IBaseRepository<Event>> logger) : base(context, logger)
        {
        }

        public override IQueryable<Event> GetAll()
        {
            return _targetTable
                .Include(e => e.Address)
                .Include(e => e.Comments)
                .Include(e => e.AttendingUsers)
                .Include(e => e.Images)
                .Include(e => e.Organizer)
                .AsQueryable();
        }

        public override async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _targetTable
                .Include(e => e.Address)
                .Include(e => e.Comments)
                .Include(e => e.AttendingUsers)
                .Include(e => e.Images)
                .Include(e => e.Organizer)
                .ToListAsync();
        }

        public override async Task<Event> GetByIdAsync(int id)
        {
            return await _targetTable
                .Include(e => e.Comments)
                .Include(e => e.AttendingUsers)
                .Include(e => e.Images)
                .Include(e => e.Address)
                .Include(e => e.Organizer)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
