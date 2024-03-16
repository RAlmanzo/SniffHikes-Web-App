using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using System.Runtime.CompilerServices;

namespace PRI.Project.Rosseel_Almanzo.Infrastructure.Data.Seeding
{
    public class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var images = new Image[]
            {
                new Image{Id = 1, UserId = 1, File = null, EventId = 1},
                new Image{Id = 2, UserId = 1, File = null, EventId = 1},
                new Image{Id = 3, UserId = 1, File = null, RouteId = 1},
                new Image{Id = 4, UserId = 1, File = null},
                new Image{Id = 5, UserId = 1, File = null},

                new Image{Id = 6, UserId = 2, File = null, EventId = 2},
                new Image{Id = 7, UserId = 2, File = null, RouteId = 2},
                new Image{Id = 8, UserId = 2, File = null, RouteId = 2},

                new Image{Id = 9, UserId = 3, File = null, EventId = 2},
                new Image{Id = 10, UserId = 3, File = null, RouteId = 2},
                new Image{Id = 11, UserId = 3, File = null},

                new Image{Id = 12, UserId = 1, File = null, EventId = 3},
                new Image{Id = 13, UserId = 1, File = null, EventId = 2},

                new Image{Id = 14, UserId = 2, File = null, RouteId = 3},
                new Image{Id = 15, UserId = 2, File = null, EventId = 1},
                new Image{Id = 16, UserId = 2, File = null, RouteId = 1},
                new Image{Id = 17, UserId = 3, File = null, RouteId = 3},
                new Image{Id = 18, UserId = 3, File = null},
            };

            var dogs = new Dog[]
            {
                new Dog{Id = 1, Name = "Inca", Race = "Husky", Gender ="Male", DateOfBirth = DateTime.Now, Image = null, UserId = 1},
                new Dog{Id = 2, Name = "Zara", Race = "Border-collie", Gender ="Female", DateOfBirth = DateTime.Now, Image = null, UserId = 1},
                new Dog{Id = 3, Name = "Sleepy", Race = "Duitse-herder", Gender ="Male", DateOfBirth = DateTime.Now, Image = null, UserId = 2},
                new Dog{Id = 4, Name = "Sleepy", Race = "Duitse-herder", Gender ="Male", DateOfBirth = DateTime.Now, Image = null, UserId = 3},
                new Dog{Id = 5, Name = "Tunder", Race = "Dog", Gender ="Female", DateOfBirth = DateTime.Now, Image = null, UserId = 1},
                new Dog{Id = 6, Name = "Zira", Race = "Husky", Gender ="Male", DateOfBirth = DateTime.Now, Image = null, UserId = 2},
            };

            var comments = new Comment[]
            {
                new Comment
                {
                    Id = 1,
                    Content = "Gezellige avond!",
                    DateCreated = DateTime.Now,
                    UserId = 1,
                    EventId = 1
                },
                new Comment
                {
                    Id = 2,
                    Content = "Leuke wandeling!",
                    DateCreated = DateTime.Now,
                    UserId = 1,
                    EventId = 2
                },
                new Comment
                {
                    Id = 3,
                    Content = "Gezellige avond!",
                    DateCreated = DateTime.Now,
                    UserId = 2,
                    EventId = 2
                },
                new Comment
                {
                    Id = 4,
                    Content = "Gezellige avond!",
                    DateCreated = DateTime.Now,
                    UserId = 3,
                    EventId = 3
                },
                new Comment
                {
                    Id = 5,
                    Content = "Mooie route!",
                    DateCreated = DateTime.Now,
                    UserId = 1,
                    RouteId = 1
                },

                new Comment
                {
                    Id = 6,
                    Content = "Leuke wandeling!",
                    DateCreated = DateTime.Now,
                    UserId = 2,
                    RouteId = 2
                },
                new Comment
                {
                    Id = 7,
                    Content = "Mooie route!",
                    DateCreated = DateTime.Now,
                    UserId = 2,
                    RouteId = 2
                },
                new Comment
                {
                    Id = 8,
                    Content = "Mooie route!",
                    DateCreated = DateTime.Now,
                    UserId = 3,
                    RouteId = 3
                },
            };

            var addresses = new Address[]
            {
                new Address { Id = 1, Street = "Rue Wayez 3", City = "Anderlecht", State = "Brussel", Country = "Belgie"},
                new Address { Id = 2, Street = "Rue Wayez 3", City = "Anderlecht", State = "Brussel", Country = "Belgie"},
                new Address { Id = 3, Street = "Veldstraat 15", City = "Gent", State = "Oost-Vlaanderen" ,Country = "Belgie"},
                new Address { Id = 4, Street = "Steenstraat 28", City = "Brugge", State = "West-Vlaanderen" ,Country = "Belgie"},
                new Address { Id = 5, Street = "Ooststraat 10", City = "Veurne", State = "West-Vlaanderen", Country = "Belgie"},
                new Address { Id = 6, Street = "Veldstraat 9", City = "Gent", State = "Oost-Vlaanderen", Country = "België"},
                new Address { Id = 7, Street = "Steenstraat 21", City = "Brugge", State = "West-Vlaanderen", Country = "België"},
                new Address { Id = 8, Street = "Meir 12", City = "Antwerpen", State = "Antwerpen", Country = "België"},
                new Address { Id = 9, Street = "Grote Markt 1", City = "Leuven", State = "Vlaams-Brabant", Country = "België"},
                //new Address { Id = 10, Street = "Groenplaats 21", City = "Mechelen", State = "Antwerpen", Country = "België"},
                //new Address { Id =11, Street = "Oude Burg 12", City = "Brugge", State = "West-Vlaanderen", Country = "België"},
            };

            var routes = new Route[]
            {
                new Route
                {
                    Id = 1,
                    UserId = 1,
                    Title = "Boswandeling",
                    Description = "Een mooie wandeling door het bos met je hond. Geniet van de natuur en de frisse lucht.",
                    AddressId = 7,
                    DateCreated = DateTime.Now,
                    //Images = images.Where(i => i.RouteId == 1).ToList(),
                    //Comments = comments.Where(c => c.RouteId == 1).ToList(),
                },
                new Route
                {
                    Id = 2,
                    UserId = 2,
                    Title = "Strandwandeling",
                    Description = "Een ontspannen wandeling met je hond langs het strand. Laat je viervoeter lekker uitwaaien!",
                    AddressId = 8,
                    DateCreated = DateTime.Now,
                    //Images = images.Where(i => i.RouteId == 2).ToList(),
                    //Comments = comments.Where(c => c.RouteId == 2).ToList(),
                },
                new Route
                {
                    Id = 3,
                    UserId = 3,
                    Title = "Parkwandeling",
                    Description = "Een leuke wandeling met je hond door het park. Laat je hond lekker rennen en spelen.",
                    AddressId = 9,
                    DateCreated = DateTime.Now,
                    //Images = images.Where(i => i.RouteId == 3).ToList(),
                    //Comments = comments.Where(c => c.RouteId == 3).ToList(),
                },
            };

            

            var users = new User[]
            {
                new User
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "DeWachter",
                    DateOfBirth = new DateTime(1980, 5, 10),
                    Gender = "male",
                    AddressId = 1,
                    Email = "",
                    Password = "",
                    //Comments = comments.Where(c => c.UserId == 1).ToList(),
                    //Dogs = dogs.Where(d => d.UserId == 1).ToList(),
                    //Routes = routes.Where(r => r.UserId == 1).ToList(),
                    //OrganizedEvents = events.Where(e => e.OrganizerId == 1).ToList(),
                    //AttendingEvents = events.Where(e => e.AttendingUsers.All(u => u.Id == 1)).ToList(),
                    //Images = images.Where(i => i.UserId == 1).ToList()
                },
                new User
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "DeWachter",
                    DateOfBirth = new DateTime(1985, 7, 15),
                    Gender = "female",
                    AddressId = 2,
                    Email = "",
                    Password = "",
                    //Comments = comments.Where(c => c.UserId == 2).ToList(),
                    //Dogs = dogs.Where(d => d.UserId == 2).ToList(),
                    //Routes = routes.Where(r => r.UserId == 2).ToList(),
                    //OrganizedEvents = events.Where(e => e.OrganizerId == 2).ToList(),
                    //AttendingEvents = events.Where(e => e.AttendingUsers.Any(u => u.Id == 2)).ToList(),
                    //Images = images.Where(i => i.UserId == 2).ToList()
                },
                new User
                {
                    Id = 3,
                    FirstName = "Jack",
                    LastName = "DeVos",
                    DateOfBirth = new DateTime(1990, 9, 20),
                    Gender = "male",
                    AddressId = 3,
                    Email = "",
                    Password = "",
                    //Comments = comments.Where(c => c.UserId == 3).ToList(),
                    //Dogs = dogs.Where(d => d.UserId == 3).ToList(),
                    //Routes = routes.Where(r => r.UserId == 3).ToList(),
                    //OrganizedEvents = events.Where(e => e.OrganizerId == 3).ToList(),
                    //AttendingEvents = events.Where(e => e.AttendingUsers.Any(u => u.Id == 3)).ToList(),
                    //Images = images.Where(i => i.UserId == 3).ToList()
                },
                //new User
                //{
                //    Id = 4,
                //    FirstName = "Jill",
                //    LastName = "Vogels",
                //    DateOfBirth = new DateTime(1995, 11, 25),
                //    Gender ="female",
                //    Address = new Address { Id= 4, Street = "Steenstraat 28", City = "Brugge", State = "West-Vlaanderen" ,Country = "Belgie"},
                //    Email = "",
                //    Password = "",
                //    Comments = comments.Where(c => c.UserId == 4).ToList(),
                //    Dogs = dogs.Where(d => d.UserId == 4).ToList(),
                //    Routes = routes.Where(r => r.UserId == 4).ToList(),
                //    OrganizedEvents = events.Where(e => e.OrganizerId == 4).ToList(),
                //    AttendingEvents = events.Where(e => e.AttendingUsers.All(u => u.Id == 4)).ToList(),
                //    Images = images.Where(i => i.UserId == 4).ToList()
                //},
                //new User
                //{
                //    Id = 5,
                //    FirstName = "Jim",
                //    LastName = "Schoonaert",
                //    DateOfBirth = new DateTime(2000, 1, 30),
                //    Gender = "male",
                //    Address = new Address {Id = 5, Street = "Ooststraat 10", City = "Veurne", State = "West-Vlaanderen", Country = "Belgie"},
                //    Email = "",
                //    Password = "",
                //    Comments = comments.Where(c => c.UserId == 5).ToList(),
                //    Dogs = dogs.Where(d => d.UserId == 5).ToList(),
                //    Routes = routes.Where(r => r.UserId == 5).ToList(),
                //    OrganizedEvents = events.Where(e => e.OrganizerId == 5).ToList(),
                //    AttendingEvents = events.Where(e => e.AttendingUsers.All(u => u.Id == 5)).ToList(),
                //    Images = images.Where(i => i.UserId == 5).ToList()
                //},               
            };

            var events = new Event[]
            {
                new Event
                {
                    Id = 1,
                    OrganizerId = 1,
                    Title = "Hondenwandeling in het bos",
                    Description = "Geniet van een ontspannen wandeling met je hond in het prachtige bosgebied. Neem je viervoeter mee voor een leuke tijd in de natuur.",
                    Price = 0,
                    AddressId = 4,
                    Date = new DateTime(2024, 4, 1, 10, 0, 0),
                    DateCreated = DateTime.Now,
                    //Images = images.Where(i => i.EventId == 1).ToList(),
                    //Comments = comments.Where(c => c.EventId == 1).ToList(),
                    //AttendingUsers = users.Where(u => u.Id == 1 || u.Id == 2).ToList(),
                },
                new Event
                {
                    Id = 2,
                    OrganizerId = 2,
                    Title = "Hondenshow Brussel",
                    Description = "Kom en bewonder verschillende hondenrassen tijdens de hondenshow in Brussel. Er zijn prijzen te winnen en veel plezier te beleven!",
                    Price = 10.50m,
                    AddressId = 5,
                    Date = new DateTime(2024, 4, 5, 12, 0, 0),
                    DateCreated = DateTime.Now,
                    //Images = images.Where(i => i.EventId == 2).ToList(),
                    //Comments = comments.Where(c => c.EventId == 2).ToList(),
                    //AttendingUsers = users.Where(u => u.Id == 2 || u.Id == 3).ToList(),
                },
                new Event
                {
                    Id = 3,
                    OrganizerId = 3,
                    Title = "Hondenwandeling aan zee",
                    Description = "Geniet van een ontspannen wandeling met je hond in het prachtige bosgebied. Neem je viervoeter mee voor een leuke tijd in de natuur.",
                    Price = 0,
                    AddressId = 6,
                    Date = new DateTime(2024, 4, 10, 10, 0, 0),
                    DateCreated = DateTime.Now,
                    //Images = images.Where(i => i.EventId == 3).ToList(),
                    //Comments = comments.Where(c => c.EventId == 3).ToList(),
                    //AttendingUsers = users.Where(u => u.Id == 1 || u.Id == 3).ToList(),
                },
            };


            modelBuilder.Entity<Image>().HasData(images);
            modelBuilder.Entity<Dog>().HasData(dogs);
            modelBuilder.Entity<Comment>().HasData(comments);
            modelBuilder.Entity<Address>().HasData(addresses);
            modelBuilder.Entity<Route>().HasData(routes);
            modelBuilder.Entity<Event>().HasData(events);
            modelBuilder.Entity<User>().HasData(users);
        }
    }
}
