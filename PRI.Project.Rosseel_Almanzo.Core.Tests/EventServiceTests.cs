using Microsoft.AspNetCore.Identity;
using Moq;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Repositories;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;
using PRI.Project.Rosseel_Almanzo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Tests
{
    public class EventServiceTests
    {
        private readonly Mock<IEventRepository> _mockEventRepository;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IEventUserRepository> _mockEventUserRepository;
        private readonly Mock<IImageRepository> _mockImageRepository;
        private readonly Mock<IAddressRepository> _mockAddressRepository;
        private readonly Mock<ICommentRepository> _mockCommentRepository;
        private readonly Mock<UserManager<User>> _mockUserManager;
        private readonly EventService _eventService;

        public EventServiceTests()
        {
            _mockEventRepository = new Mock<IEventRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockEventUserRepository = new Mock<IEventUserRepository>();
            _mockImageRepository = new Mock<IImageRepository>();
            _mockAddressRepository = new Mock<IAddressRepository>();
            _mockCommentRepository = new Mock<ICommentRepository>();

            _mockUserManager = new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);

            _eventService = new EventService(_mockEventRepository.Object, _mockUserRepository.Object, _mockEventUserRepository.Object,_mockAddressRepository.Object, _mockImageRepository.Object, _mockCommentRepository.Object, _mockUserManager.Object);
        }

        [Fact]
        public async Task CreateEventAsync_WithValidOrganizer_ReturnsSuccess()
        {
            // Arrange
            var organizerId = "1";
            var eventCreateRequestModel = new EventCreateRequestModel
            {
                Title = "New Event",
                Description = "Event Description",
                Price = 100,
                Date = DateTime.Now.AddDays(10),
                Street = "Street",
                City = "City",
                State = "State",
                Country = "Country",
                OrganizerId = organizerId,
                Images = new List<string> { "image.jpg" }
            };

            var organizer = new User { Id = organizerId };

            _mockUserRepository.Setup(repo => repo.GetByIdAsync(organizerId)).ReturnsAsync(organizer);
            _mockUserManager.Setup(manager => manager.GetClaimsAsync(organizer)).ReturnsAsync(new List<Claim>());
            _mockUserManager.Setup(manager => manager.AddClaimAsync(organizer, It.IsAny<Claim>())).ReturnsAsync(IdentityResult.Success);
            _mockEventRepository.Setup(repo => repo.AddAsync(It.IsAny<Event>())).ReturnsAsync(true);
            _mockEventRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Event { Id = 1 });

            // Act
            var result = await _eventService.CreateEventAsync(eventCreateRequestModel);

            // Assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task CreateEventAsync_WithInValidOrganizer_ReturnsError()
        {
            // Arrange
            var eventCreateRequestModel = new EventCreateRequestModel
            {
                OrganizerId = "invalid_organizer_id"
            };

            _mockUserRepository.Setup(repo => repo.GetByIdAsync(eventCreateRequestModel.OrganizerId)).ReturnsAsync((User)null);

            // Act
            var result = await _eventService.CreateEventAsync(eventCreateRequestModel);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Orginazer does not exist!", result.Errors);
        }

        [Fact]
        public async Task CreateEventAsync_AddClaimFails_ReturnsError()
        {
            // Arrange
            var organizerId = "1";
            var eventCreateRequestModel = new EventCreateRequestModel
            {
                OrganizerId = organizerId
            };

            var organizer = new User { Id = organizerId };

            _mockUserRepository.Setup(repo => repo.GetByIdAsync(organizerId)).ReturnsAsync(organizer);
            _mockUserManager.Setup(manager => manager.GetClaimsAsync(organizer)).ReturnsAsync(new List<Claim>());
            _mockUserManager.Setup(manager => manager.AddClaimAsync(organizer, It.IsAny<Claim>())).ReturnsAsync(IdentityResult.Failed());

            // Act
            var result = await _eventService.CreateEventAsync(eventCreateRequestModel);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Failed: could not add claim, please contact admin", result.Errors);
        }

        [Fact]
        public async Task CreateEventAsync_AddEventFails_ReturnsError()
        {
            // Arrange
            var organizerId = "1";
            var eventCreateRequestModel = new EventCreateRequestModel
            {
                OrganizerId = organizerId,
                Title = "Event Title",
                Description = "Event Description",
                Price = 100,
                Date = DateTime.Now.AddDays(10),
                Street = "Street",
                City = "City",
                State = "State",
                Country = "Country",
                Images = new List<string> { "image.jpg" }
            };

            var organizer = new User { Id = organizerId };

            _mockUserRepository.Setup(repo => repo.GetByIdAsync(organizerId)).ReturnsAsync(organizer);
            _mockUserManager.Setup(manager => manager.GetClaimsAsync(organizer)).ReturnsAsync(new List<Claim>());
            _mockUserManager.Setup(manager => manager.AddClaimAsync(organizer, It.IsAny<Claim>())).ReturnsAsync(IdentityResult.Success);
            _mockEventRepository.Setup(repo => repo.AddAsync(It.IsAny<Event>())).ReturnsAsync(false);

            // Act
            var result = await _eventService.CreateEventAsync(eventCreateRequestModel);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Event not created!", result.Errors);
        }

        [Fact]
        public async Task DeleteEventAsync_WithValidEventId_ReturnsSuccess()
        {
            // Arrange
            var eventId = 1;
            var selectedEvent = new Event { Id = eventId, AddressId = 1 };
            var eventAddress = new Address { Id = 1 };
            var eventUsers = new List<EventUser>();
            var eventImages = new List<Image>();
            var eventComments = new List<Comment>();

            _mockEventRepository.Setup(repo => repo.GetByIdAsync(eventId)).ReturnsAsync(selectedEvent);
            _mockAddressRepository.Setup(repo => repo.GetByIdAsync(selectedEvent.AddressId)).ReturnsAsync(eventAddress);
            _mockEventUserRepository.Setup(repo => repo.GetAllByEventId(eventId)).ReturnsAsync(eventUsers);
            _mockEventRepository.Setup(repo => repo.GetAllEventImages(eventId)).Returns(eventImages.AsQueryable());
            _mockEventRepository.Setup(repo => repo.GetAllEventComments(eventId)).Returns(eventComments.AsQueryable());
            _mockEventRepository.Setup(repo => repo.DeleteAsync(selectedEvent)).ReturnsAsync(true);
            _mockAddressRepository.Setup(repo => repo.DeleteAsync(eventAddress)).ReturnsAsync(true);

            // Act
            var result = await _eventService.DeleteEventAsync(eventId);

            // Assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task DeleteEventAsync_WithInvalidId_ReturnsError()
        {
            // Arrange
            var eventId = 1;

            _mockEventRepository.Setup(repo => repo.GetByIdAsync(eventId)).ReturnsAsync((Event)null);

            // Act
            var result = await _eventService.DeleteEventAsync(eventId);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Event does not exist!", result.Errors);
        }

        [Fact]
        public async Task DeleteEventAsync_WithSomeErrorOccuredDeleteEventFailsMessage_ReturnsErrorMessage()
        {
            // Arrange
            var eventId = 1;
            var selectedEvent = new Event { Id = eventId, AddressId = 1 };
            var eventAddress = new Address { Id = 1 };
            var eventUsers = new List<EventUser>();
            var eventImages = new List<Image>();
            var eventComments = new List<Comment>();

            _mockEventRepository.Setup(repo => repo.GetByIdAsync(eventId)).ReturnsAsync(selectedEvent);
            _mockAddressRepository.Setup(repo => repo.GetByIdAsync(selectedEvent.AddressId)).ReturnsAsync(eventAddress);
            _mockEventUserRepository.Setup(repo => repo.GetAllByEventId(eventId)).ReturnsAsync(eventUsers);
            _mockEventRepository.Setup(repo => repo.GetAllEventImages(eventId)).Returns(eventImages.AsQueryable());
            _mockEventRepository.Setup(repo => repo.GetAllEventComments(eventId)).Returns(eventComments.AsQueryable());
            _mockEventRepository.Setup(repo => repo.DeleteAsync(selectedEvent)).ReturnsAsync(false);

            // Act
            var result = await _eventService.DeleteEventAsync(eventId);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Some error occured!", result.Errors);
        }

        [Fact]
        public async Task GetAllAsync_WithEventsCountGreaterThenZero_ReturnsEvents()
        {
            // Arrange
            var events = new List<Event> { new Event { Id = 1 }, new Event { Id = 2 } };
            _mockEventRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(events);

            // Act
            var result = await _eventService.GetAllAsync();

            // Assert
            Assert.True(result.Success);
            Assert.Equal(events, result.Value);
        }

        [Fact]
        public async Task GetAllAsync_WithNoEvents_ReturnsError()
        {
            // Arrange
            _mockEventRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<Event>());

            // Act
            var result = await _eventService.GetAllAsync();

            // Assert
            Assert.False(result.Success);
            Assert.Contains("No events found", result.Errors);
        }

        [Fact]
        public async Task GetByIdAsync_WithExistingEvent_ReturnsEvent()
        {
            // Arrange
            var eventId = 1;
            var selectedEvent = new Event { Id = eventId, AttendingUsers = new List<EventUser> { new EventUser { UserId = "1" } } };
            var user = new User { Id = "1" };

            _mockEventRepository.Setup(repo => repo.GetByIdAsync(eventId)).ReturnsAsync(selectedEvent);
            _mockUserRepository.Setup(repo => repo.GetByIdAsync("1")).ReturnsAsync(user);

            // Act
            var result = await _eventService.GetByIdAsync(eventId);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(selectedEvent, result.Value);
        }

        [Fact]
        public async Task GetByIdAsync_WithEventDoesNotExist_ReturnsError()
        {
            // Arrange
            var eventId = 1;
            _mockEventRepository.Setup(repo => repo.GetByIdAsync(eventId)).ReturnsAsync((Event)null);

            // Act
            var result = await _eventService.GetByIdAsync(eventId);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("No event found", result.Errors);
        }

        [Fact]
        public async Task CheckIfExistsAsync_WithValidEventId_ReturnsTrue()
        {
            // Arrange
            var eventId = 1;
            _mockEventRepository.Setup(repo => repo.CheckIfExistsAsync(eventId)).ReturnsAsync(true);

            // Act
            var result = await _eventService.CheckIfExistsAsync(eventId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task CheckIfExistsAsync_WithInvalidEventId_ReturnsFalse()
        {
            // Arrange
            var eventId = 1;
            _mockEventRepository.Setup(repo => repo.CheckIfExistsAsync(eventId)).ReturnsAsync(false);

            // Act
            var result = await _eventService.CheckIfExistsAsync(eventId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task UpdateEventAsync_WithValidEventId_ReturnsUpdatedEvent()
        {
            // Arrange
            var eventUpdateRequestModel = new EventUpdateRequestModel
            {
                Id = 1,
                Title = "Updated Title",
                Description = "Updated Description",
                Price = 50,
                Street = "Updated Street",
                City = "Updated City",
                State = "Updated State",
                Country = "Updated Country",
                OrganizerId = "1",
                Date = DateTime.Now.AddDays(1),
                DateCreated = DateTime.Now
            };

            var selectedEvent = new Event { Id = 1, Address = new Address() };
            var organizer = new User { Id = "1" };

            _mockUserRepository.Setup(repo => repo.GetAll()).Returns(new List<User> { organizer }.AsQueryable());
            _mockEventRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(selectedEvent);
            _mockEventRepository.Setup(repo => repo.UpdateAsync(selectedEvent)).ReturnsAsync(true);

            // Act
            var result = await _eventService.UpdateEventAsync(eventUpdateRequestModel);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(eventUpdateRequestModel.Title, result.Value.Title);
        }

        [Fact]
        public async Task UpdateEventAsync_WithInvalidOrganizer_ReturnsError()
        {
            // Arrange
            var eventUpdateRequestModel = new EventUpdateRequestModel { OrganizerId = "1" };
            _mockUserRepository.Setup(repo => repo.GetAll()).Returns(new List<User>().AsQueryable());

            // Act
            var result = await _eventService.UpdateEventAsync(eventUpdateRequestModel);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Orginazer does not exist!", result.Errors);
        }

        [Fact]
        public async Task AddImageAsync_WithValidEventId_ReturnsUpdatedEvent()
        {
            // Arrange
            var eventId = 1;
            var imagePath = "path/to/image.jpg";
            var selectedEvent = new Event { Id = eventId };

            _mockEventRepository.Setup(repo => repo.GetAll()).Returns(new List<Event> { selectedEvent }.AsQueryable());
            _mockImageRepository.Setup(repo => repo.AddAsync(It.IsAny<Image>())).ReturnsAsync(true);
            _mockEventRepository.Setup(repo => repo.GetByIdAsync(eventId)).ReturnsAsync(selectedEvent);

            // Act
            var result = await _eventService.AddImageAsync(eventId, imagePath);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(selectedEvent, result.Value);
        }

        [Fact]
        public async Task AddImageAsync_WithInvalidEventId_ReturnsError()
        {
            // Arrange
            var eventId = 1;
            var imagePath = "path/to/image.jpg";

            _mockEventRepository.Setup(repo => repo.GetAll()).Returns(new List<Event>().AsQueryable());

            // Act
            var result = await _eventService.AddImageAsync(eventId, imagePath);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Event does not exist!", result.Errors);
        }

        [Fact]
        public async Task SearchByTitleAsync_WithEventsTitleEqualToSearchInput_ReturnsEvents()
        {
            // Arrange
            var title = "Sample";
            var events = new List<Event>
            {
                new Event { Title = "Sample Event 1" },
                new Event { Title = "Another Sample Event" }
            };

            _mockEventRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(events);

            // Act
            var result = await _eventService.SearchByTitleAsync(title);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(2, result.Value.Count());
        }

        [Fact]
        public async Task SearchByTitleAsync_WithNoEventsWithTitleEqualToSearchInput_ReturnsError()
        {
            // Arrange
            var title = "Sample";
            _mockEventRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<Event>());

            // Act
            var result = await _eventService.SearchByTitleAsync(title);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("No events found", result.Errors);
        }

    }
}
