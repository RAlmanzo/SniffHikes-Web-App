using Moq;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Repositories;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;
using PRI.Project.Rosseel_Almanzo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Tests
{
    public class RoutesServiceTests
    {
        private readonly Mock<IRouteRepository> _mockRouteRepository;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IAddressRepository> _mockAddressRepository;
        private readonly Mock<IImageRepository> _mockImageRepository;
        private readonly Mock<ICommentRepository> _mockCommentRepository;
        private readonly RouteService _routeService;

        public RoutesServiceTests()
        {
            _mockRouteRepository = new Mock<IRouteRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockAddressRepository = new Mock<IAddressRepository>();
            _mockImageRepository = new Mock<IImageRepository>();
            _mockCommentRepository = new Mock<ICommentRepository>();

            _routeService = new RouteService( _mockRouteRepository.Object, _mockUserRepository.Object,
                _mockAddressRepository.Object, _mockImageRepository.Object, _mockCommentRepository.Object);
        }

        [Fact]
        public async Task GetAllAsync_WithoutValidRoutesList_ReturnsAllRoutes()
        {
            // Arrange
            var routes = new List<Route> { new Route { Id = 1 }, new Route { Id = 2 } };
            _mockRouteRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(routes);

            // Act
            var result = await _routeService.GetAllAsync();

            // Assert
            Assert.True(result.Success);
            Assert.Equal(routes, result.Value);
        }

        [Fact]
        public async Task GetAllAsync_WithoutExistingRoutesList_ReturnsError()
        {
            // Arrange
            _mockRouteRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<Route>());

            // Act
            var result = await _routeService.GetAllAsync();

            // Assert
            Assert.False(result.Success);
            Assert.Contains("No routes found", result.Errors);
        }

        [Fact]
        public async Task GetByIdAsync_WithValidRouteId_ReturnsRoute()
        {
            // Arrange
            var routeId = 1;
            var route = new Route { Id = routeId };

            _mockRouteRepository.Setup(repo => repo.GetByIdAsync(routeId)).ReturnsAsync(route);

            // Act
            var result = await _routeService.GetByIdAsync(routeId);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(route, result.Value);
        }

        [Fact]
        public async Task GetByIdAsync_WithInvalidRouteId_ReturnsError()
        {
            // Arrange
            var routeId = 1;
            _mockRouteRepository.Setup(repo => repo.GetByIdAsync(routeId)).ReturnsAsync((Route)null);

            // Act
            var result = await _routeService.GetByIdAsync(routeId);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("No route found", result.Errors);
        }

        [Fact]
        public async Task CheckIfExistsAsync_WithExistingRouteId_ReturnsTrue()
        {
            // Arrange
            var routeId = 1;
            _mockRouteRepository.Setup(repo => repo.CheckIfExistsAsync(routeId)).ReturnsAsync(true);

            // Act
            var result = await _routeService.CheckIfExistsAsync(routeId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task CheckIfExistsAsync_WithInvalidRouteId_ReturnsFalse()
        {
            // Arrange
            var routeId = 1;
            _mockRouteRepository.Setup(repo => repo.CheckIfExistsAsync(routeId)).ReturnsAsync(false);

            // Act
            var result = await _routeService.CheckIfExistsAsync(routeId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task CreateRouteAsync_WithValidOrganizerId_ReturnsSuccesIsTrue()
        {
            // Arrange
            var routeCreateRequestModel = new RouteCreateRequestModel
            {
                OrganizerId = "1",
                Title = "New Route",
                Description = "Route Description",
                Street = "Street",
                City = "City",
                State = "State",
                Country = "Country",
                Images = new List<string> { "path/to/image.jpg" }
            };

            var organizer = new User { Id = "1" };

            _mockUserRepository.Setup(repo => repo.GetAll()).Returns(new List<User> { organizer }.AsQueryable());
            _mockRouteRepository.Setup(repo => repo.AddAsync(It.IsAny<Route>())).ReturnsAsync(true);

            // Act
            var result = await _routeService.CreateRouteAsync(routeCreateRequestModel);

            // Assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task CreateRouteAsync_WithInValidOrganizerId_ReturnsError()
        {
            // Arrange
            var routeCreateRequestModel = new RouteCreateRequestModel { OrganizerId = "1" };
            _mockUserRepository.Setup(repo => repo.GetAll()).Returns(new List<User>().AsQueryable());

            // Act
            var result = await _routeService.CreateRouteAsync(routeCreateRequestModel);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Orginazer does not exist!", result.Errors);
        }

        [Fact]
        public async Task UpdateRouteAsync_WithValidRouteId_ReturnsUpdatedRoute()
        {
            // Arrange
            var routeUpdateRequestModel = new RouteUpdateRequestModel
            {
                Id = 1,
                Title = "Updated Title",
                Description = "Updated Description",
                Street = "Updated Street",
                City = "Updated City",
                State = "Updated State",
                Country = "Updated Country",
                OrganizerId = "1"
            };

            var route = new Route { Id = 1, Address = new Address() };
            var organizer = new User { Id = "1" };

            _mockUserRepository.Setup(repo => repo.GetAll()).Returns(new List<User> { organizer }.AsQueryable());
            _mockRouteRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(route);
            _mockRouteRepository.Setup(repo => repo.UpdateAsync(route)).ReturnsAsync(true);

            // Act
            var result = await _routeService.UpdateRouteAsync(routeUpdateRequestModel);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(routeUpdateRequestModel.Title, result.Value.Title);
        }

        [Fact]
        public async Task UpdateRouteAsync_WithInValidOrganizerId_ReturnsError()
        {
            // Arrange
            var routeUpdateRequestModel = new RouteUpdateRequestModel { OrganizerId = "1" };
            _mockUserRepository.Setup(repo => repo.GetAll()).Returns(new List<User>().AsQueryable());

            // Act
            var result = await _routeService.UpdateRouteAsync(routeUpdateRequestModel);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Orginazer does not exist!", result.Errors);
        }

        [Fact]
        public async Task DeleteRouteAsync_WithValidRouteId_ReturnsSuccesIsTrue()
        {
            // Arrange
            var routeId = 1;
            var route = new Route { Id = routeId, AddressId = 1 };
            var address = new Address { Id = 1 };
            var comments = new List<Comment> { new Comment { Id = 1 } }.AsQueryable();
            var images = new List<Image> { new Image { Id = 1 } }.AsQueryable();

            _mockRouteRepository.Setup(repo => repo.GetByIdAsync(routeId)).ReturnsAsync(route);
            _mockAddressRepository.Setup(repo => repo.GetByIdAsync(route.AddressId)).ReturnsAsync(address);
            _mockRouteRepository.Setup(repo => repo.GetAllRouteComments(routeId)).Returns(comments);
            _mockRouteRepository.Setup(repo => repo.GetAllRouteImages(routeId)).Returns(images);
            _mockRouteRepository.Setup(repo => repo.DeleteAsync(route)).ReturnsAsync(true);
            _mockAddressRepository.Setup(repo => repo.DeleteAsync(address)).ReturnsAsync(true);
            _mockImageRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Image>())).ReturnsAsync(true);
            _mockCommentRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Comment>())).ReturnsAsync(true);

            // Act
            var result = await _routeService.DeleteRouteAsync(routeId);

            // Assert
            Assert.True(result.Success);
        }


        [Fact]
        public async Task DeleteRouteAsync_WithInValidRouteId_ReturnsError()
        {
            // Arrange
            var routeId = 1;
            _mockRouteRepository.Setup(repo => repo.GetByIdAsync(routeId)).ReturnsAsync((Route)null);

            // Act
            var result = await _routeService.DeleteRouteAsync(routeId);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Route does not exist!", result.Errors);
        }

        [Fact]
        public async Task AddImageAsync_WithValidRoute_ReturnsSuccesIsTrue()
        {
            // Arrange
            var routeId = 1;
            var imagePath = "path/to/image.jpg";
            var route = new Route { Id = routeId };

            _mockRouteRepository.Setup(repo => repo.GetAll()).Returns(new List<Route> { route }.AsQueryable());
            _mockImageRepository.Setup(repo => repo.AddAsync(It.IsAny<Image>())).ReturnsAsync(true);

            // Act
            var result = await _routeService.AddImageAsync(routeId, imagePath);

            // Assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task AddImageAsync_WithInvalidRouteId_ReturnsError()
        {
            // Arrange
            var routeId = 1;
            var imagePath = "path/to/image.jpg";

            _mockRouteRepository.Setup(repo => repo.GetAll()).Returns(new List<Route>().AsQueryable());

            // Act
            var result = await _routeService.AddImageAsync(routeId, imagePath);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Route does not exist!", result.Errors);
        }

        [Fact]
        public async Task SearchByTitleAsync_WithRouteTitlesEqualToSearchInput_ReturnsRoutes()
        {
            // Arrange
            var title = "Route Title";
            var routes = new List<Route> { new Route { Id = 1, Title = title } };
            _mockRouteRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(routes);

            // Act
            var result = await _routeService.SearchByTitleAsync(title);

            // Assert
            Assert.True(result.Success);
            Assert.NotNull(result.Value);
        }

        [Fact]
        public async Task SearchByTitleAsync_WithNoRouteTitleEqualToSearchInput_ReturnsError()
        {
            // Arrange
            var title = "Route Title";
            _mockRouteRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<Route>());

            // Act
            var result = await _routeService.SearchByTitleAsync(title);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("No routes found", result.Errors);
        }
    }
}
