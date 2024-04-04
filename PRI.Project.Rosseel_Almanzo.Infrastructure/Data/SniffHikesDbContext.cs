using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Infrastructure.Data.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Infrastructure.Data
{
    public class SniffHikesDbContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<EventUser> EventsUser { get; set; }

        public SniffHikesDbContext(DbContextOptions<SniffHikesDbContext> 
            options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dog>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);
            
            modelBuilder.Entity<Event>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Event>()
                .Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(750);
            modelBuilder.Entity<Event>()
                .Property(p => p.Price)
                .HasColumnType("money");
            modelBuilder.Entity<Event>()
                .HasOne(u => u.Organizer)
                .WithMany(e => e.OrganizedEvents)
                .HasForeignKey(e => e.OrganizerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Route>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Route>()
                .Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(750);
            modelBuilder.Entity<Route>()
                .HasOne(r => r.Address);
            modelBuilder.Entity<Route>()
                .HasOne(r => r.User)
                .WithMany(u => u.Routes)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .Property(p => p.Content)
                .IsRequired()
                .HasMaxLength(200);
           modelBuilder.Entity<EventUser>()
                .HasKey(e => new {e.UserId, e.EventId});
            modelBuilder.Entity<EventUser>()
                .HasOne(u => u.User)
                .WithMany(e => e.AttendingEvents)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EventUser>()
                .HasOne(u => u.Event)
                .WithMany(e => e.AttendingUsers)
                .HasForeignKey(u => u.EventId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>()
                .HasMany(u => u.OrganizedEvents)
                .WithOne(e => e.Organizer)
                .HasForeignKey(e => e.OrganizerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Address);

            Seeder.Seed(modelBuilder);
        }
    }
}
