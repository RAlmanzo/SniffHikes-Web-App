using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace PRI.Project.Rosseel_Almanzo.Core.Tests
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IAddressRepository> _mockAddressRepository;
        private readonly Mock<IEventUserRepository> _mockEventUserRepository;
        private readonly Mock<IEventRepository> _mockEventRepository;
        private readonly Mock<IDogRepository> _mockDogRepository;
        private readonly Mock<UserManager<User>> _mockUserManager;
        private readonly Mock<SignInManager<User>> _mockSignInManager;
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly Mock<IHttpContextAccessor> _mockHttpContextAccessor;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockAddressRepository = new Mock<IAddressRepository>();
            _mockEventUserRepository = new Mock<IEventUserRepository>();
            _mockEventRepository = new Mock<IEventRepository>();
            _mockDogRepository = new Mock<IDogRepository>();

            _mockUserManager = new Mock<UserManager<User>>(
                new Mock<IUserStore<User>>().Object, null, null, null, null, null, null, null, null);

            _mockSignInManager = new Mock<SignInManager<User>>(_mockUserManager.Object,
                new Mock<IHttpContextAccessor>().Object,
                new Mock<IUserClaimsPrincipalFactory<User>>().Object, null, null, null, null);

            _mockConfiguration = new Mock<IConfiguration>();
            _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();

            var httpContext = new DefaultHttpContext();
            _mockHttpContextAccessor.Setup(x => x.HttpContext).Returns(httpContext);

            _userService = new UserService(_mockUserRepository.Object, _mockAddressRepository.Object,_mockEventUserRepository.Object, _mockEventRepository.Object,
                _mockDogRepository.Object, _mockUserManager.Object, _mockSignInManager.Object, _mockConfiguration.Object, _mockHttpContextAccessor.Object);
        }

        [Fact]
        public async Task CreateUserAsync_WithValidEmail_ReturnsSuccessIsTrue()
        {
            // Arrange
            var password = "password";
            var email = "test@test.com";
            var user = new User
            {
                UserName = email,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1990, 1, 1),
                Gender = "Male",
                Email = email,
                EmailConfirmed = true,
                Image = "image.png",
                Address = new Address
                {
                    Street = "123 Main St",
                    City = "Anytown",
                    State = "Anystate",
                    Country = "Anycountry",
                }
            };

            var userCreateRequestModel = new UserCreateRequestModel
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "test@test.com",
                Password = password,
                Address = new Address
                {
                    Street = "123 Main St",
                    City = "Anytown",
                    State = "Anystate",
                    Country = "Anycountry"
                },
                DateOfBirth = new DateTime(1990, 1, 1),
                Gender = "Male",
                Image = "image.png",
            };

            _mockUserManager.Setup(um => um.FindByEmailAsync(email)).ReturnsAsync((User)null);
            _mockUserManager.Setup(um => um.CreateAsync(It.IsAny<User>(), password)).ReturnsAsync(IdentityResult.Success);
            _mockUserManager.Setup(um => um.AddClaimsAsync(It.IsAny<User>(), It.IsAny<IEnumerable<Claim>>())).ReturnsAsync(IdentityResult.Success);

            _mockUserRepository.Setup(up => up.AddAsync(It.IsAny<User>(), password)).ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _userService.CreateUserAsync(userCreateRequestModel);

            // Assert
            Assert.True(result.Success);
        }


        [Fact]
        public async Task CreateUserAsync_WithEmailAllreadyExcists_ReturnsError()
        {
            // Arrange
            var userCreateRequestModel = new UserCreateRequestModel { Email = "test@test.com" };
            _mockUserManager.Setup(um => um.FindByEmailAsync(userCreateRequestModel.Email))
                .ReturnsAsync(new User());

            // Act
            var result = await _userService.CreateUserAsync(userCreateRequestModel);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Email allready exists!", result.Errors);
        }

        [Fact]
        public async Task DeleteUserAsync_WithValidUserId_ReturnsSuccessIsTrue()
        {
            // Arrange
            var userId = "1";
            var user = new User { Id = userId, AddressId = 1 };
            var address = new Address { Id = 1 };

            _mockUserRepository.Setup(repo => repo.GetByIdAsync(userId)).ReturnsAsync(user);
            _mockAddressRepository.Setup(repo => repo.GetByIdAsync(user.AddressId)).ReturnsAsync(address);
            _mockUserRepository.Setup(repo => repo.DeleteAsync(user)).ReturnsAsync(IdentityResult.Success);
            _mockAddressRepository.Setup(repo => repo.DeleteAsync(address)).ReturnsAsync(true);

            // Act
            var result = await _userService.DeleteUserAsync(userId);

            // Assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task DeleteUserAsync_WithInValidUserId_ReturnsError()
        {
            // Arrange
            var userId = "1";
            _mockUserRepository.Setup(repo => repo.GetByIdAsync(userId)).ReturnsAsync((User)null);

            // Act
            var result = await _userService.DeleteUserAsync(userId);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("User does not exist!", result.Errors);
        }

        [Fact]
        public async Task GetByIdAsync_WithValidUserId_ReturnsUser()
        {
            // Arrange
            var userId = "1";
            var user = new User { Id = userId };
            _mockUserRepository.Setup(repo => repo.GetByIdAsync(userId)).ReturnsAsync(user);

            // Act
            var result = await _userService.GetByIdAsync(userId);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(userId, result.Value.Id);
        }

        [Fact]
        public async Task GetByIdAsync_WithInvalidUserId_ReturnsError()
        {
            // Arrange
            var userId = "1";
            _mockUserRepository.Setup(repo => repo.GetByIdAsync(userId)).ReturnsAsync((User)null);

            // Act
            var result = await _userService.GetByIdAsync(userId);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("User not found", result.Errors);
        }

        [Fact]
        public async Task UpdateUserAsync_WithValidUserId_ReturnsUpdatedUser()
        {
            // Arrange
            var userId = "1";
            var userUpdateRequestModel = new UserUpdateRequestModel
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe",
                Address = new Address
                {
                    Street = "123 Main St",
                    City = "Anytown",
                    State = "Anystate",
                    Country = "Anycountry"
                },
                DateOfBirth = new DateTime(1990, 1, 1),
                Gender = "Male",
                Image = "image.png"
            };

            var user = new User
            {
                Id = userId,
                FirstName = "Jane",
                LastName = "Doe",
                Address = new Address
                {
                    Street = "456 Elm St",
                    City = "Othertown",
                    State = "Otherstate",
                    Country = "Othercountry"
                },
                DateOfBirth = new DateTime(1991, 2, 2),
                Gender = "Female",
                Image = "oldimage.png"
            };

            _mockUserRepository.Setup(repo => repo.GetByIdAsync(userId)).ReturnsAsync(user);
            _mockUserRepository.Setup(repo => repo.UpdateAsync(It.IsAny<User>())).ReturnsAsync(true);

            // Act
            var result = await _userService.UpdateUserAsync(userUpdateRequestModel);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(userUpdateRequestModel.Id, user.Id);
        }

        [Fact]
        public async Task UpdateUserAsync_WithInValidUserId_ReturnsError()
        {
            // Arrange
            var userUpdateRequestModel = new UserUpdateRequestModel
            {
                Id = "1",
                FirstName = "John",
                LastName = "Doe",
                Address = new Address
                {
                    Street = "123 Main St",
                    City = "Anytown",
                    State = "Anystate",
                    Country = "Anycountry"
                },
                DateOfBirth = new DateTime(1990, 1, 1),
                Gender = "Male",
                Image = "image.png"
            };

            _mockUserRepository.Setup(repo => repo.GetByIdAsync(userUpdateRequestModel.Id)).ReturnsAsync((User)null);

            // Act
            var result = await _userService.UpdateUserAsync(userUpdateRequestModel);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("User update failed!", result.Errors);
        }
    }
}
