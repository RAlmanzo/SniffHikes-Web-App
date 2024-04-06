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
    public class RouteRepository : BaseRepository<Route>, IRouteRepository
    {
        public RouteRepository(SniffHikesDbContext context, ILogger<IBaseRepository<Route>> logger) : base(context, logger)
        {
        }

        public override IQueryable<Route> GetAll()
        {
            return _targetTable
                .Include(e => e.Address)
                .Include(e => e.Comments)
                .Include(e => e.Images)
                .Include(e => e.User)
                .AsQueryable();
        }

        public override async Task<IEnumerable<Route>> GetAllAsync()
        {
            return await _targetTable
                .Include(e => e.Address)
                .Include(e => e.Comments)
                .Include(e => e.Images)
                .Include(e => e.User)
                .ToListAsync();
        }

        public override async Task<Route> GetByIdAsync(int id)
        {
            return await _targetTable
                .Include(e => e.Comments)
                .Include(e => e.Images)
                .Include(e => e.Address)
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public IQueryable<Comment> GetAllRouteComments(int id)
        {
            var route = GetByIdAsync(id);

            return route.Result.Comments.AsQueryable();
        }

        public IQueryable<Image> GetAllRouteImages(int id)
        {
            var route = GetByIdAsync(id);

            return route.Result.Images.AsQueryable();
        }
    }
}
