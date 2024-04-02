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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SniffHikesDbContext context, ILogger<IBaseRepository<User>> logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            var data = await _targetTable
                .Include(u => u.Address)
                .Include(u => u.Comments)
                .Include(u => u.Dogs)
                .Include(u => u.Routes)
                .Include(u => u.OrganizedEvents)
                .Include(u => u.AttendingEvents)
                .ToListAsync();
            return data;
        }

        public override async Task<User> GetByIdAsync(int id)
        {
            return await _targetTable
                .Include(u => u.Address)
                .Include(u => u.Comments)
                .Include(u => u.Dogs)
                .Include(u => u.Routes)
                .Include(u => u.OrganizedEvents)
                .Include(u => u.AttendingEvents)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
