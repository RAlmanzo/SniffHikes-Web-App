using Microsoft.AspNetCore.Routing;
using PRI.Project.Rosseel_Almanzo.Api.Dtos;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using Route = PRI.Project.Rosseel_Almanzo.Core.Entities.Route;

namespace PRI.Project.Rosseel_Almanzo.Api.Extensions
{
    public static class DtoExtensions
    {
        // DtoExtensions for event
        public static EventsGetAllResponseDto MapToDto(this IEnumerable<Event> events)
        {
            return new EventsGetAllResponseDto
            {
                Events = events.Select(e => new BaseDto
                {
                    Id = e.Id,
                    Value = e.Title,
                    Image = e.Images.FirstOrDefault().File,
                    organizerId = e.OrganizerId,
                })
            };
        }

        public static EventsGetResponseDto MapToDto(this Event selectedEvent)
        {
            return new EventsGetResponseDto
            {
                Id = selectedEvent.Id,
                Value = selectedEvent.Title,
                Description = selectedEvent.Description,
                Price = selectedEvent.Price,
                Date = selectedEvent.Date,
                DateCreated = DateTime.Now,
                Orginazer = new BaseUserDto
                {
                    Id = selectedEvent.OrganizerId,
                    Value = $"{selectedEvent.Organizer.FirstName} {selectedEvent.Organizer.LastName}",
                },
                Address = new AddressDto
                {
                    Id = selectedEvent.AddressId,
                    Street = selectedEvent.Address.Street,
                    City = selectedEvent.Address.City,
                    State = selectedEvent.Address.State,
                    Country = selectedEvent.Address.Country,
                    Value = $"{selectedEvent.Address.Street} {selectedEvent.Address.City} {selectedEvent.Address.State} {selectedEvent.Address.Country}",
                },
                Images = selectedEvent.Images.Select(i => new BaseDto
                {
                    Id = i.Id,
                    Value = i.File,
                }),
                Comments = selectedEvent.Comments.Select(c => new BaseDto
                {
                    Id = c.Id,
                    Value = c.Content,
                }),
                Users = selectedEvent.AttendingUsers.Select(u => new BaseUserDto
                {
                    Id = u.UserId,
                    Value = $"{u.User.FirstName} {u.User.LastName}",
                }),
            };
        }

        // DtoExtensions for user
        public static UsersGetAllResponseDto MapToDto(this IEnumerable<User> users)
        {
            return new UsersGetAllResponseDto
            {
                Users = users.Select(e => new BaseUserDto
                {
                    Id = e.Id,
                    Value = $"{e.LastName} {e.FirstName}",
                    Image = e.Image,
                })
            };
        }

        public static UsersGetResponseDto MapToDto(this User user)
        {
            return new UsersGetResponseDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Value = $"{user.LastName} {user.FirstName}",
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                Email = user.Email,
                Image = user.Image,
                Address = new AddressDto
                {
                    Id = user.AddressId,
                    Street = user.Address.Street,
                    City = user.Address.City,
                    State = user.Address.State,
                    Country = user.Address.Country,
                    Value = $"{user.Address.Street} {user.Address.City} {user.Address.State} {user.Address.Country}",
                },
                Dogs = user.Dogs.Select(d => new BaseDto
                {
                    Id = d.Id,
                    Value = d.Name,
                    Image = d.Image,
                }),
                Comments = user.Comments.Select(u => new BaseDto
                {
                    Id = u.Id,
                    Value = u.Content,
                }),
                AttendingEvents = user.AttendingEvents.Select(e => new BaseDto
                {
                    Id = (int)e.EventId,
                    Value = e.Event.Title,
                    Image = e.Event.Images.FirstOrDefault().File,
                }),
                OrganizedEvents = user.OrganizedEvents.Select(e => new BaseDto
                {
                    Id = (int)e.Id,
                    Value = e.Title,
                    Image = e.Images != null ? e.Images.FirstOrDefault()?.File : null
                }).ToList(),
            };
        }

        // DtoExtensions for route
        public static RoutesGetAllResponseDto MapToDto(this IEnumerable<Route> routes)
        {
            return new RoutesGetAllResponseDto
            {
                Routes = routes.Select(e => new BaseDto
                {
                    Id = e.Id,
                    Value = e.Title,
                    Image = e.Images.FirstOrDefault().File,
                    organizerId = e.UserId,
                })
            };
        }

        public static RoutesGetResponseDto MapToDto(this Route route)
        {
            return new RoutesGetResponseDto
            {
                Id = route.Id,
                Value = route.Title,
                Description = route.Description,
                DateCreated = DateTime.Now,
                Orginazer = new BaseUserDto
                {
                    Id = route.UserId,
                    Value = $"{route.User.FirstName} {route.User.LastName}",
                },
                Address = new AddressDto
                {
                    Id = route.AddressId,
                    Street = route.Address.Street,
                    City = route.Address.City,
                    State = route.Address.State,
                    Country = route.Address.Country,
                    Value = $"{route.Address.Street} {route.Address.City} {route.Address.State} {route.Address.Country}",
                },
                Images = route.Images.Select(i => new BaseDto
                {
                    Id = i.Id,
                    Value = i.File,
                }),
                Comments = route.Comments.Select(c => new BaseDto
                {
                    Id = c.Id,
                    Value = c.Content,
                }),
            };
        }

        // DtoExtensions for dog
        public static DogsGetAllResponseDto MapToDto(this IEnumerable<Dog> dogs)
        {
            return new DogsGetAllResponseDto
            {
                Dogs = dogs.Select(e => new BaseDto
                {
                    Id = e.Id,
                    Value = e.Name,
                    Image = e.Image,
                })
            };
        }
    }
}
