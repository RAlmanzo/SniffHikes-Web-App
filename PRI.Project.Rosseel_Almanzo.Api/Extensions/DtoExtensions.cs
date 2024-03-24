using PRI.Project.Rosseel_Almanzo.Api.Dtos;
using PRI.Project.Rosseel_Almanzo.Core.Entities;

namespace PRI.Project.Rosseel_Almanzo.Api.Extensions
{
    public static class DtoExtensions
    {
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
                Orginazer = new BaseDto
                {
                    Id = selectedEvent.OrganizerId,
                    Value = $"{selectedEvent.Organizer.FirstName} {selectedEvent.Organizer.LastName}",
                },
                //Address = $"{result.Value.Address.Street} {result.Value.Address.City} {result.Value.Address.State} {result.Value.Address.Country}",
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
                    Id = u.Id,
                    Value = $"{u.FirstName} {u.LastName}",
                }),
            };
        }
    }
}
