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
                new Image{Id = 1, File = null, EventId = 1},
                new Image{Id = 2, File = null, EventId = 1},
                new Image{Id = 3, File = null, RouteId = 1},

                new Image{Id = 6 , File = null, EventId = 2},
                new Image{Id = 7, File = null, RouteId = 2},
                new Image{Id = 8, File = null, RouteId = 2},

                new Image{Id = 9, File = null, EventId = 2},
                new Image{Id = 10, File = null, RouteId = 2},

                new Image{Id = 12, File = null, EventId = 3},
                new Image{Id = 13, File = null, EventId = 2},

                new Image{Id = 14, File = null, RouteId = 3},
                new Image{Id = 15, File = null, EventId = 1},
                new Image{Id = 16, File = null, RouteId = 1},
                new Image{Id = 17, File = null, RouteId = 3},
            };

            var dogs = new Dog[]
            {
                new Dog{Id = 1, Name = "Inca", Race = "Husky", Gender ="Male", DateOfBirth = DateTime.Now, Image = null, UserId = 1},
                new Dog{Id = 2, Name = "Zara", Race = "Border-collie", Gender ="Female", DateOfBirth = DateTime.Now, Image = null, UserId = 1},
                new Dog{Id = 3, Name = "Sleepy", Race = "Duitse-herder", Gender ="Male", DateOfBirth = DateTime.Now, Image = null, UserId = 2},
                new Dog{Id = 4, Name = "Sleepy", Race = "Duitse-herder", Gender ="Male", DateOfBirth = DateTime.Now, Image = null, UserId = 3},
                new Dog{Id = 5, Name = "Tunder", Race = "Dog", Gender ="Female", DateOfBirth = DateTime.Now, Image = null, UserId = 1},
                new Dog{Id = 6, Name = "Zira", Race = "Husky", Gender ="Male", DateOfBirth = DateTime.Now, Image = null, UserId = 2},
                new Dog{Id = 7, Name = "Bella", Race = "Labrador Retriever", Gender = "Female", DateOfBirth = new DateTime(2019, 5, 12), Image = null, UserId = 4},
                new Dog{Id = 8, Name = "Rocky", Race = "German Shepherd", Gender = "Male", DateOfBirth = new DateTime(2018, 10, 8), Image = null, UserId = 4},
                new Dog{Id = 9, Name = "Luna", Race = "Golden Retriever", Gender = "Female", DateOfBirth = new DateTime(2020, 3, 21), Image = null, UserId = 5},
                new Dog{Id = 10, Name = "Max", Race = "Poodle", Gender = "Male", DateOfBirth = new DateTime(2017, 12, 3), Image = null, UserId = 5},
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
                new Address { Id = 10, Street = "Groenplaats 21", City = "Mechelen", State = "Antwerpen", Country = "België"},
                new Address { Id =11, Street = "Oude Burg 12", City = "Brugge", State = "West-Vlaanderen", Country = "België"},
                new Address { Id = 12, Street = "Veldstraat 9", City = "Gent", State = "Oost-Vlaanderen", Country = "België"},
                new Address { Id = 13, Street = "Steenstraat 21", City = "Brugge", State = "West-Vlaanderen", Country = "België"},
                new Address { Id = 14, Street = "Rue Wayez 3", City = "Anderlecht", State = "Brussel", Country = "Belgie"},
                new Address { Id = 15, Street = "Rue Wayez 3", City = "Anderlecht", State = "Brussel", Country = "Belgie"},
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
                },
                new Route
                {
                    Id = 2,
                    UserId = 2,
                    Title = "Strandwandeling",
                    Description = "Een ontspannen wandeling met je hond langs het strand. Laat je viervoeter lekker uitwaaien!",
                    AddressId = 8,
                    DateCreated = DateTime.Now,
                },
                new Route
                {
                    Id = 3,
                    UserId = 3,
                    Title = "Parkwandeling",
                    Description = "Een leuke wandeling met je hond door het park. Laat je hond lekker rennen en spelen.",
                    AddressId = 9,
                    DateCreated = DateTime.Now,
                },
                new Route
                {
                    Id = 4,
                    UserId = 4,
                    Title = "Strandwandeling",
                    Description = "Een ontspannen wandeling met je hond langs het strand. Laat je viervoeter lekker uitwaaien!",
                    AddressId = 14,
                    DateCreated = DateTime.Now,
                },
                new Route
                {
                    Id = 5,
                    UserId = 5,
                    Title = "Parkwandeling",
                    Description = "Een leuke wandeling met je hond door het park. Laat je hond lekker rennen en spelen.",
                    AddressId = 15,
                    DateCreated = DateTime.Now,
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
                },
                new User
                {
                    Id = 4,
                    FirstName = "Jill",
                    LastName = "Vogels",
                    DateOfBirth = new DateTime(1995, 11, 25),
                    Gender ="female",
                    AddressId = 10,
                    Email = "",
                    Password = "",
                },
                new User
                {
                    Id = 5,
                    FirstName = "Jim",
                    LastName = "Schoonaert",
                    DateOfBirth = new DateTime(2000, 1, 30),
                    Gender = "male",
                    AddressId = 11,
                    Email = "",
                    Password = "",
                },
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
                },
                new Event
                {
                    Id = 4,
                    OrganizerId = 4,
                    Title = "Hondenshow West-Vlaanderen",
                    Description = "Kom en bewonder verschillende hondenrassen tijdens de hondenshow in Brussel. Er zijn prijzen te winnen en veel plezier te beleven!",
                    Price = 10.50m,
                    AddressId = 12,
                    Date = new DateTime(2024, 4, 5, 12, 0, 0),
                    DateCreated = DateTime.Now,
                },
                new Event
                {
                    Id = 5,
                    OrganizerId = 4,
                    Title = "Hondenwandeling Heuvelland",
                    Description = "Geniet van een ontspannen wandeling met je hond in het prachtige bosgebied. Neem je viervoeter mee voor een leuke tijd in de natuur.",
                    Price = 0,
                    AddressId = 13,
                    Date = new DateTime(2024, 4, 10, 10, 0, 0),
                    DateCreated = DateTime.Now,
                },
            };

            var eventUsers = new EventUser[]
            {
                new EventUser { UserId = 1, EventId = 1 },
                new EventUser { UserId = 2, EventId = 1 },
                new EventUser { UserId = 2, EventId = 2 },
                new EventUser { UserId = 3, EventId = 2 },
                new EventUser { UserId = 1, EventId = 3 },
                new EventUser { UserId = 3, EventId = 3 },
                new EventUser { UserId = 4, EventId = 5 },
                new EventUser { UserId = 4, EventId = 4 },
                new EventUser { UserId = 5, EventId = 5 },
            };


            modelBuilder.Entity<Image>().HasData(images);
            modelBuilder.Entity<Dog>().HasData(dogs);
            modelBuilder.Entity<Comment>().HasData(comments);
            modelBuilder.Entity<Address>().HasData(addresses);
            modelBuilder.Entity<Route>().HasData(routes);
            modelBuilder.Entity<Event>().HasData(events);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<EventUser>().HasData(eventUsers);
        }
    }
}
