using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace PRI.Project.Rosseel_Almanzo.Infrastructure.Data.Seeding
{
    public class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var images = new Image[]
            {
                new Image{Id = 1, File = "AHiken.jpeg", EventId = 1},
                new Image{Id = 2, File = "IMG_20210516_165116.jpg", EventId = 1},
                new Image{Id = 3, File = "IMG_20210516_171528.jpg", EventId = 1},
                new Image{Id = 4 ,File = "Schermafbeelding 2024-06-15 173550.png", EventId = 2},
                new Image{Id = 5, File = "Schermafbeelding 2023-11-03 203719.png", EventId = 2},
                new Image{Id = 6, File = "Schermafbeelding 2024-06-15 173812.png", EventId = 2},
                new Image{Id = 7, File = "FB_IMG_1676153401593.jpg", EventId = 3},
                new Image{Id = 8, File = "IMG_20210613_150444.jpg", EventId = 3},
                new Image{Id = 9, File = "Schermafbeelding 2024-06-15 175152.png", EventId = 4},
                new Image{Id = 10, File = "IMG_20210620_161504.jpg", EventId = 5},

                new Image{Id = 11, File = "IMG_20210620_152407.jpg", RouteId = 1},
                new Image{Id = 12, File = "IMG_20210620_154507.jpg", RouteId = 1},
                new Image{Id = 13, File = "IMG_20210620_154515.jpg", RouteId = 1},   
                new Image{Id = 14, File = "Schermafbeelding 2024-06-15 180613.png", RouteId = 2},
                new Image{Id = 15, File = "Schermafbeelding 2024-06-15 180627.png", RouteId = 2},            
                new Image{Id = 16, File = "Schermafbeelding 2024-06-15 180646.png", RouteId = 2},
                new Image{Id = 17, File = "Schermafbeelding 2024-06-15 180856.png", RouteId = 3},
                new Image{Id = 18, File = "Schermafbeelding 2024-06-15 180954.png", RouteId = 3},
                new Image{Id = 19, File = "Schermafbeelding 2024-06-15 181114.png", RouteId = 4},
                new Image{Id = 20, File = "Schermafbeelding 2024-06-15 181021.png", RouteId = 5},
            };

            var dogs = new Dog[]
            {
                new Dog{Id = 1, Name = "Inca", Race = "Husky", Gender ="Male", DateOfBirth = DateTime.Now, Image = "inca2.jpg", UserId = "1"},
                new Dog{Id = 2, Name = "Zara", Race = "Border-collie", Gender ="Female", DateOfBirth = DateTime.Now, Image = "FB_IMG_1676153391880.jpg", UserId = "1"},
                new Dog{Id = 3, Name = "Zira", Race = "Husky", Gender ="Male", DateOfBirth = DateTime.Now, Image = "IMG_20201118_121810.jpg", UserId = "2"},
                new Dog{Id = 4, Name = "Sleepy", Race = "Duitse-herder", Gender ="Male", DateOfBirth = DateTime.Now, Image = "received_455341335122662.jpeg", UserId = "2"},
                new Dog{Id = 5, Name = "Sleepy", Race = "Duitse-herder", Gender ="Male", DateOfBirth = DateTime.Now, Image = "IMG_20210613_142801.jpg", UserId = "3"},             
                new Dog{Id = 7, Name = "Luna", Race = "Golden Retriever", Gender = "Female", DateOfBirth = new DateTime(2020, 3, 21), Image = "IMG_20210619_162819.jpg", UserId = "4"},
                new Dog{Id = 8, Name = "Max", Race = "Poodle", Gender = "Male", DateOfBirth = new DateTime(2017, 12, 3), Image = "received_421419258529965.jpeg", UserId = "5"},
            };

            var comments = new Comment[]
            {
                new Comment
                {
                    Id = 1,
                    Content = "Gezellige avond!",
                    DateCreated = DateTime.Now,
                    UserId = "1",
                    EventId = 1
                },
                new Comment
                {
                    Id = 2,
                    Content = "Leuke wandeling!",
                    DateCreated = DateTime.Now,
                    UserId = "1",
                    EventId = 2
                },
                new Comment
                {
                    Id = 3,
                    Content = "Gezellige avond!",
                    DateCreated = DateTime.Now,
                    UserId = "2",
                    EventId = 2
                },
                new Comment
                {
                    Id = 4,
                    Content = "Gezellige avond!",
                    DateCreated = DateTime.Now,
                    UserId = "3",
                    EventId = 3
                },
                new Comment
                {
                    Id = 5,
                    Content = "Mooie route!",
                    DateCreated = DateTime.Now,
                    UserId = "1",
                    RouteId = 1
                },

                new Comment
                {
                    Id = 6,
                    Content = "Leuke wandeling!",
                    DateCreated = DateTime.Now,
                    UserId = "2",
                    RouteId = 2
                },
                new Comment
                {
                    Id = 7,
                    Content = "Mooie route!",
                    DateCreated = DateTime.Now,
                    UserId = "2",
                    RouteId = 2
                },
                new Comment
                {
                    Id = 8,
                    Content = "Mooie route!",
                    DateCreated = DateTime.Now,
                    UserId = "4",
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
                    UserId = "1",
                    Title = "HellegatBos wandeling",
                    Description = "Een mooie wandeling door het bos met je hond. Geniet van de natuur en de frisse lucht.",
                    AddressId = 7,
                    DateCreated = DateTime.Now,
                },
                new Route
                {
                    Id = 2,
                    UserId = "2",
                    Title = "Strandwandeling DePanne",
                    Description = "Een ontspannen wandeling met je hond langs het strand. Laat je viervoeter lekker uitwaaien!",
                    AddressId = 8,
                    DateCreated = DateTime.Now,
                },
                new Route
                {
                    Id = 3,
                    UserId = "3",
                    Title = "Parkwandeling Brussel",
                    Description = "Een leuke wandeling met je hond door het park. Laat je hond lekker rennen en spelen.",
                    AddressId = 9,
                    DateCreated = DateTime.Now,
                },
                new Route
                {
                    Id = 4,
                    UserId = "4",
                    Title = "Strandwandeling Oostende",
                    Description = "Een ontspannen wandeling met je hond langs het strand. Laat je viervoeter lekker uitwaaien!",
                    AddressId = 14,
                    DateCreated = DateTime.Now,
                },
                new Route
                {
                    Id = 5,
                    UserId = "5",
                    Title = "Parkwandeling Brugge",
                    Description = "Een leuke wandeling met je hond door het park. Laat je hond lekker rennen en spelen.",
                    AddressId = 15,
                    DateCreated = DateTime.Now,
                },
            };

            //seed users with roles
            var admin = new User
            {
                Id = "1",
                UserName = "admin@pri.be",
                NormalizedUserName = "ADMIN@PRI.BE",
                FirstName = "John",
                LastName = "DeWachter",
                DateOfBirth = new DateTime(1980, 5, 10),
                Gender = "male",
                AddressId = 1,
                Email = "admin@pri.be",
                NormalizedEmail = "ADMIN@PRI.BE",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                Image = "FB_IMG_1676153444794.jpg",
            };
            var user1 = new User
            {
                Id = "2",
                UserName = "user@pri.be",
                NormalizedUserName = "USER@PRI.BE",
                FirstName = "Jane",
                LastName = "DeWachter",
                DateOfBirth = new DateTime(1985, 7, 15),
                Gender = "female",
                AddressId = 2,
                Email = "user@pri.be",
                NormalizedEmail = "USER@PRI.BE",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                Image = "AInca&me_153848.jpeg",
            };
            var user2 = new User
            {
                Id = "3",
                UserName = "orginazer@pri.be",
                NormalizedUserName = "ORGINAZER@PRI.BE",
                FirstName = "Jack",
                LastName = "DeVos",
                DateOfBirth = new DateTime(1990, 9, 20),
                Gender = "male",
                AddressId = 3,
                Email = "orginazer@pri.be",
                NormalizedEmail = "ORGINAZER@PRI.BE",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                Image = "received_3074607475886000.jpeg",
            };
            var user3 = new User
            {
                Id = "4",
                UserName = "jill@pri.be",
                NormalizedUserName = "JILL@PRI.BE",
                FirstName = "Jill",
                LastName = "Vogels",
                DateOfBirth = new DateTime(1995, 11, 25),
                Gender = "female",
                AddressId = 10,
                Email = "jill@pri.be",
                NormalizedEmail = "JILL@PRI.BE",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
            };
            var user4 = new User
            {
                Id = "5",
                UserName = "jim@pri.be",
                NormalizedUserName = "JIM@PRI.BE",
                FirstName = "Jim",
                LastName = "Schoonaert",
                DateOfBirth = new DateTime(2000, 1, 30),
                Gender = "male",
                AddressId = 11,
                Email = "jim@pri.be",
                NormalizedEmail = "JIM@PRI.BE",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
            };
            IPasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            //TODO password aanpassen na testing!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            admin.PasswordHash = passwordHasher.HashPassword(admin, "Test123?");
            user1.PasswordHash = passwordHasher.HashPassword(user1, "Test123?");
            user2.PasswordHash = passwordHasher.HashPassword(user2, "Test123?");
            user3.PasswordHash = passwordHasher.HashPassword(user3, "Test123?");
            user4.PasswordHash = passwordHasher.HashPassword(user4, "Test123?");
            //claims
            //role claims
            var userClaims = new IdentityUserClaim<string>[]
            {
                //admin
                new IdentityUserClaim<string>
                {
                    Id = 1,
                    UserId = "1",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "Admin"
                },
                new IdentityUserClaim<string>
                {
                    Id = 2,
                    UserId = "1",
                    ClaimType = ClaimTypes.DateOfBirth,
                    ClaimValue = admin.DateOfBirth.ToString(),
                },
                new IdentityUserClaim<string>
                {
                    Id = 3,
                    UserId = "1",
                    ClaimType = ClaimTypes.Email,
                    ClaimValue = admin.Email,
                },
                new IdentityUserClaim<string>
                {
                    Id = 4,
                    UserId = "1",
                    ClaimType = ClaimTypes.NameIdentifier,
                    ClaimValue = admin.Id,
                },
                //user1
                new IdentityUserClaim<string>
                {
                    Id = 5,
                    UserId = "2",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "User"
                },           
                new IdentityUserClaim<string>
                {
                    Id = 6,
                    UserId = "2",
                    ClaimType = ClaimTypes.DateOfBirth,
                    ClaimValue = user1.DateOfBirth.ToString(),
                },               
                new IdentityUserClaim<string>
                {
                    Id = 7,
                    UserId = "2",
                    ClaimType = ClaimTypes.Email,
                    ClaimValue = user1.Email,
                },             
                new IdentityUserClaim<string>
                {
                    Id = 8,
                    UserId = "2",
                    ClaimType = ClaimTypes.NameIdentifier,
                    ClaimValue = user1.Id,
                },

                //user2
                new IdentityUserClaim<string>
                {
                    Id = 9,
                    UserId = "3",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "User"
                },
                new IdentityUserClaim<string>
                {
                    Id = 10,
                    UserId = "3",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "Orginazer"
                },
                new IdentityUserClaim<string>
                {
                    Id = 11,
                    UserId = "3",
                    ClaimType = ClaimTypes.DateOfBirth,
                    ClaimValue = user2.DateOfBirth.ToString(),
                },
                new IdentityUserClaim<string>
                {
                    Id = 12,
                    UserId = "3",
                    ClaimType = ClaimTypes.Email,
                    ClaimValue = user2.Email,
                },
                new IdentityUserClaim<string>
                {
                    Id = 13,
                    UserId = "3",
                    ClaimType = ClaimTypes.NameIdentifier,
                    ClaimValue = user2.Id,
                },

                //user3
                new IdentityUserClaim<string>
                {
                    Id = 14,
                    UserId = "4",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "User"
                },
                new IdentityUserClaim<string>
                {
                    Id = 15,
                    UserId = "4",
                    ClaimType = ClaimTypes.DateOfBirth,
                    ClaimValue = user3.DateOfBirth.ToString(),
                },
                new IdentityUserClaim<string>
                {
                    Id = 16,
                    UserId = "4",
                    ClaimType = ClaimTypes.Email,
                    ClaimValue = user3.Email,
                },
                new IdentityUserClaim<string>
                {
                    Id = 17,
                    UserId = "4",
                    ClaimType = ClaimTypes.NameIdentifier,
                    ClaimValue = user3.Id,
                },

                //user4
                new IdentityUserClaim<string>
                {
                    Id = 18,
                    UserId = "5",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "User"
                },
                new IdentityUserClaim<string>
                {
                    Id = 19,
                    UserId = "5",
                    ClaimType = ClaimTypes.DateOfBirth,
                    ClaimValue = user4.DateOfBirth.ToString(),
                },
                new IdentityUserClaim<string>
                {
                    Id = 20,
                    UserId = "5",
                    ClaimType = ClaimTypes.Email,
                    ClaimValue = user4.Email,
                },
                new IdentityUserClaim<string>
                {
                    Id = 21,
                    UserId = "5",
                    ClaimType = ClaimTypes.NameIdentifier,
                    ClaimValue = user4.Id,
                },

                new IdentityUserClaim<string>
                {
                    Id = 22,
                    UserId = "1",
                    ClaimType = "profile-image",
                    ClaimValue = admin.Image,
                },
                new IdentityUserClaim<string>
                {
                    Id = 23,
                    UserId = "2",
                    ClaimType = "profile-image",
                    ClaimValue = user1.Image,
                },
                new IdentityUserClaim<string>
                {
                    Id = 24,
                    UserId = "3",
                    ClaimType = "profile-image",
                    ClaimValue = user2.Image,
                },
            };

            var events = new Event[]
            {
                new Event
                {
                    Id = 1,
                    OrganizerId = "1",
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
                    OrganizerId = "2",
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
                    OrganizerId = "3",
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
                    OrganizerId = "4",
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
                    OrganizerId = "5",
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
                new EventUser { UserId = "1", EventId = 1 },
                new EventUser { UserId = "2", EventId = 1 },
                new EventUser { UserId = "2", EventId = 2 },
                new EventUser { UserId = "3", EventId = 2 },
                new EventUser { UserId = "1", EventId = 3 },
                new EventUser { UserId = "3", EventId = 3 },
                new EventUser { UserId = "4", EventId = 5 },
                new EventUser { UserId = "4", EventId = 4 },
                new EventUser { UserId = "5", EventId = 5 },
            };

            modelBuilder.Entity<Image>().HasData(images);
            modelBuilder.Entity<Dog>().HasData(dogs);
            modelBuilder.Entity<Comment>().HasData(comments);
            modelBuilder.Entity<Address>().HasData(addresses);
            modelBuilder.Entity<Route>().HasData(routes);
            modelBuilder.Entity<Event>().HasData(events);
            modelBuilder.Entity<User>().HasData(admin, user1, user2, user3, user4);
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(userClaims);
            modelBuilder.Entity<EventUser>().HasData(eventUsers);
        }
    }
}
