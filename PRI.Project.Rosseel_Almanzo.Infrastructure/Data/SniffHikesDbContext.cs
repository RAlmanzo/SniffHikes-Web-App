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
            modelBuilder.Entity<Dog>()
                .Property(p => p.Race)
                .IsRequired();
            
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


            //modelBuilder.Entity<Event>()
            //    .HasMany(e => e.AttendingUsers)
            //    .WithMany(u => u.AttendingEvents);

            //modelBuilder.Entity<Event>()
            //    .HasOne(e => e.Address);
            //modelBuilder.Entity<Event>()
            //    .HasOne(u => u.Organizer)
            //    .WithMany(e => e.OrganizedEvents)
            //    .HasForeignKey(u => u.OrganizerId)
            //    .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity<User>()
                .HasMany(u => u.OrganizedEvents)
                .WithOne(e => e.Organizer)
                .HasForeignKey(e => e.OrganizerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
                .HasMany(u => u.AttendingEvents)
                .WithMany(e => e.AttendingUsers)
                .UsingEntity(j => j.ToTable("EventUser"));


            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Comments)
            //    .WithOne(c => c.User)
            //    .OnDelete(DeleteBehavior.Restrict);
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

            //modelBuilder.Entity($"{nameof(Event)}{nameof(User)}");

            //modelBuilder.Entity<Event>()
            //    .HasMany(e => e.AttendingUsers)
            //    .WithMany(u => u.AttendingEvents)
            //    .UsingEntity(j =>
            //    {
            //        j.ToTable("EventUser"); // Naam van de tussentabel
            //        j.HasKey("AttendingEventsId", "AttendingUsersId"); // Samengestelde sleutel
            //        j.HasOne<Event>().WithMany().HasForeignKey("AttendingEventsId").OnDelete(DeleteBehavior.Restrict); // ForeignKey naar Event
            //        j.HasOne<User>().WithMany().HasForeignKey("AttendingUsersId").OnDelete(DeleteBehavior.Restrict); // ForeignKey naar User
            //    });

            //modelBuilder.Entity<Event>()
            //    .HasMany(e => e.AttendingUsers)
            //    .WithMany(u => u.AttendingEvents)
            //    .UsingEntity(
            //        j =>
            //        {
            //            j.ToTable("EventUser"); // Naam van de tussentabel
            //            j.HasKey("AttendingEventsId", "AttendingUsersId"); // Samengestelde sleutel
            //            j.HasOne(eu => eu.Event)
            //                .WithMany()
            //                .HasForeignKey("AttendingEventsId")
            //                .OnDelete(DeleteBehavior.Restrict); // ForeignKey naar Event
            //            j.HasOne(eu => eu.User)
            //                .WithMany()
            //                .HasForeignKey("AttendingUsersId")
            //                .OnDelete(DeleteBehavior.Restrict); // ForeignKey naar User
            //        });


            Seeder.Seed(modelBuilder);
        }
    }
}
