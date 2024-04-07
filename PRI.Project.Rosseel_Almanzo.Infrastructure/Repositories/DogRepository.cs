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
    public class DogRepository : BaseRepository<Dog>, IDogRepository
    {
        public DogRepository(SniffHikesDbContext context, ILogger<IBaseRepository<Dog>> logger) : base(context, logger)
        {
        }
    }
}
