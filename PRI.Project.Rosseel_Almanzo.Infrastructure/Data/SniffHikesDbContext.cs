using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Infrastructure.Data
{
    public class SniffHikesDbContext : DbContext
    {
        public SniffHikesDbContext(DbContextOptions<SniffHikesDbContext> 
            options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Seeder.Seed(modelBuilder);
        }
    }
}
