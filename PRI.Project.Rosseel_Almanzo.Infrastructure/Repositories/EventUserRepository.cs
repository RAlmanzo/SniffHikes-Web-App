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
    public class EventUserRepository : IEventUserRepository
    {
        private readonly SniffHikesDbContext _dbContext;
        protected readonly DbSet<EventUser> _targetTable;
        private readonly ILogger<IEventUserRepository> _logger;

        public EventUserRepository(SniffHikesDbContext context, ILogger<IEventUserRepository> logger)
        {
            _dbContext = context;
            _targetTable = _dbContext.Set<EventUser>();
            _logger = logger;
        }
        public async Task<bool> DeleteAsync(EventUser toDelete)
        {
            _targetTable.Remove(toDelete);
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<EventUser>> GetAllByUserId(int id)
        {
            return await _targetTable.Where(u => u.UserId == id).ToListAsync();
        }

        public async Task<IEnumerable<EventUser>> GetAllByEventId(int id)
        {
            return await _targetTable.Where(u => u.EventId == id).ToListAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException dbUpdateException)
            {
                _logger.LogError(dbUpdateException.Message);
                return false;
            }
        }
    }
}
