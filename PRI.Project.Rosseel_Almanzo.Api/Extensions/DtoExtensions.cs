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
                Orginazer = selectedEvent.OrganizerId.HasValue ? new BaseDto
                {
                    Id = selectedEvent.OrganizerId.Value,
                    Value = $"{selectedEvent.Organizer.FirstName} {selectedEvent.Organizer.LastName}",
                }
                : null,
                Address = new BaseDto
                {
                    Id = selectedEvent.AddressId,
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
                Users = selectedEvent.AttendingUsers.Select(u => new BaseDto
                {
                    Id = (int)u.UserId,
                    Value = $"{u.User.FirstName} {u.User.LastName}",
                }),
            };
        }

        // DtoExtensions for user
        public static UsersGetAllResponseDto MapToDto(this IEnumerable<User> users)
        {
            return new UsersGetAllResponseDto
            {
                Users = users.Select(e => new BaseDto
                {
                    Id = e.Id,
                    Value = $"{e.LastName} {e.FirstName}",
                })
            };
        }

        public static UsersGetResponseDto MapToDto(this User user)
        {
            return new UsersGetResponseDto
            {
                Id = user.Id,
                Value = $"{user.LastName} {user.FirstName}",
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                Email = user.Email,
                Password = user.Password,
                Image = user.Image,
                Address = new BaseDto
                {
                    Id = user.AddressId,
                    Value = $"{user.Address.Street} {user.Address.City} {user.Address.State} {user.Address.Country}",
                },
                Dogs = user.Dogs.Select(d => new BaseDto
                {
                    Id = d.Id,
                    Value = d.Name,
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
                }),
                OrganizedEvents = user.OrganizedEvents.Select(e => new BaseDto
                {
                    Id = (int)e.Id,
                    Value = e.Title,
                }),
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
                Orginazer = route.UserId.HasValue ? new BaseDto
                {
                    Id = route.UserId.Value,
                    Value = $"{route.User.FirstName} {route.User.LastName}",
                }
                : null,
                Address = new BaseDto
                {
                    Id = route.AddressId,
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
    }
}
