using Moq;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Repositories;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services;
using PRI.Project.Rosseel_Almanzo.Core.Services;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Tests
{
    public class DogServiceTests
    {
        private readonly Mock<IDogRepository> _mockDogRepository;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IEventRepository> _mockEventRepository;
        private readonly DogService _dogService;

        public DogServiceTests()
        {
            _mockDogRepository = new Mock<IDogRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockEventRepository = new Mock<IEventRepository>();
            _dogService = new DogService(_mockDogRepository.Object, _mockUserRepository.Object, _mockEventRepository.Object);
        }

        [Fact]
        public async Task AddDogAsync_WithValidUser_ReturnsSuccess()
        {
            // Arrange
            var userId = "1";
            var dogCreateRequestModel = new DogCreateRequestModel
            {
                Name = "Buddy",
                Race = "Labrador",
                Gender = "Male",
                DateOfBirth = new DateTime(2020, 1, 1),
                Image = "image.jpg",
                UserId = userId
            };

            _mockUserRepository.Setup(repo => repo.GetAll()).Returns(new List<User> { new User { Id = userId } }.AsQueryable());
            _mockDogRepository.Setup(repo => repo.AddAsync(It.IsAny<Dog>())).ReturnsAsync(true);
            _mockUserRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(new User { Id = userId, AttendingEvents = new List<EventUser>() });

            // Act
            var result = await _dogService.AddDogAsync(dogCreateRequestModel);

            // Assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task AddDogAsync_WithNonExistingUser_ReturnsError()
        {
            // Arrange
            var dogCreateRequestModel = new DogCreateRequestModel
            {
                Name = "Buddy",
                Race = "Labrador",
                Gender = "Male",
                DateOfBirth = new DateTime(2020, 1, 1),
                Image = "image.jpg",
                UserId = "invalid_user_id"
            };

            _mockUserRepository.Setup(repo => repo.GetAll()).Returns(new List<User>().AsQueryable());

            // Act
            var result = await _dogService.AddDogAsync(dogCreateRequestModel);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("User does not exist!", result.Errors);
        }

        [Fact]
        public async Task AddDogAsync_WithAddAsyncFalse_ReturnsErrorDogNotCreated()
        {
            // Arrange
            var userId = "1";
            var dogCreateRequestModel = new DogCreateRequestModel
            {
                Name = "Buddy",
                Race = "Labrador",
                Gender = "Male",
                DateOfBirth = new DateTime(2020, 1, 1),
                Image = "image.jpg",
                UserId = userId
            };

            _mockUserRepository.Setup(repo => repo.GetAll()).Returns(new List<User> { new User { Id = userId } }.AsQueryable());
            _mockDogRepository.Setup(repo => repo.AddAsync(It.IsAny<Dog>())).ReturnsAsync(false);

            // Act
            var result = await _dogService.AddDogAsync(dogCreateRequestModel);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Dog not created!", result.Errors);
        }
        [Fact]
        public async Task DeleteDogAsync_WithValidDogId_ReturnsSuccess()
        {
            // Arrange
            var dogId = 1;
            var dog = new Dog { Id = dogId };

            _mockDogRepository.Setup(repo => repo.GetByIdAsync(dogId)).ReturnsAsync(dog);
            _mockDogRepository.Setup(repo => repo.DeleteAsync(dog)).ReturnsAsync(true);

            // Act
            var result = await _dogService.DeleteDogAsync(dogId);

            // Assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task DeleteDogAsync_WithNonExistingDogId_ReturnsError()
        {
            // Arrange
            var dogId = 500;

            _mockDogRepository.Setup(repo => repo.GetByIdAsync(dogId)).ReturnsAsync((Dog)null);

            // Act
            var result = await _dogService.DeleteDogAsync(dogId);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Dog does not exist!", result.Errors);
        }

        [Fact]
        public async Task DeleteDogAsync_WithDogRepoError_ReturnsError()
        {
            // Arrange
            var dogId = 1;
            var dog = new Dog { Id = dogId };

            _mockDogRepository.Setup(repo => repo.GetByIdAsync(dogId)).ReturnsAsync(dog);
            _mockDogRepository.Setup(repo => repo.DeleteAsync(dog)).ReturnsAsync(false);

            // Act
            var result = await _dogService.DeleteDogAsync(dogId);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Some error occured!", result.Errors);
        }

        [Fact]
        public async Task GetByIdAsync_WithValidId_ReturnsDog()
        {
            // Arrange
            var dogId = 1;
            var dog = new Dog { Id = dogId };

            _mockDogRepository.Setup(repo => repo.GetByIdAsync(dogId)).ReturnsAsync(dog);

            // Act
            var result = await _dogService.GetByIdAsync(dogId);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(dog, result.Value);
        }

        [Fact]
        public async Task GetByIdAsync_WithInvalidId_ReturnsError()
        {
            // Arrange
            var dogId = 1;

            _mockDogRepository.Setup(repo => repo.GetByIdAsync(dogId)).ReturnsAsync((Dog)null);

            // Act
            var result = await _dogService.GetByIdAsync(dogId);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Dog not found", result.Errors);
        }

        [Fact]
        public async Task UpdateDogAsync_WithValidData_ReturnsSuccesAndUpdatedDog()
        {
            // Arrange
            var userId = "1";
            var dogUpdateRequestModel = new DogUpdateRequestModel
            {
                Id = 1,
                Name = "Buddy Updated",
                Race = "Labrador",
                Gender = "Male",
                DateOfBirth = new DateTime(2020, 1, 1),
                UserId = userId
            };
            var dog = new Dog { Id = dogUpdateRequestModel.Id };

            _mockUserRepository.Setup(repo => repo.GetAll()).Returns(new List<User> { new User { Id = userId } }.AsQueryable());
            _mockUserRepository.Setup(repo => repo.GetAllUserDogs(userId)).Returns(new List<Dog> { dog }.AsQueryable());
            _mockDogRepository.Setup(repo => repo.GetByIdAsync(dogUpdateRequestModel.Id)).ReturnsAsync(dog);
            _mockDogRepository.Setup(repo => repo.UpdateAsync(dog)).ReturnsAsync(true);

            // Act
            var result = await _dogService.UpdateDogAsync(dogUpdateRequestModel);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(dogUpdateRequestModel.Id, result.Value.Id);
        }

        [Fact]
        public async Task UpdateDogAsync_WithNonExistingUser_ReturnsError()
        {
            // Arrange
            var dogUpdateRequestModel = new DogUpdateRequestModel
            {
                Id = 1,
                Name = "Buddy Updated",
                Race = "Labrador",
                Gender = "Male",
                DateOfBirth = new DateTime(2020, 1, 1),
                UserId = "invalid_user_id"
            };

            _mockUserRepository.Setup(repo => repo.GetAll()).Returns(new List<User>().AsQueryable());

            // Act
            var result = await _dogService.UpdateDogAsync(dogUpdateRequestModel);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("User does not exist!", result.Errors);
        }

        [Fact]
        public async Task UpdateDogAsync_WithUserIsNotOwner_ReturnsError()
        {
            // Arrange
            var userId = "1";
            var dogUpdateRequestModel = new DogUpdateRequestModel
            {
                Id = 1,
                Name = "Buddy Updated",
                Race = "Labrador",
                Gender = "Male",
                DateOfBirth = new DateTime(2020, 1, 1),
                UserId = userId
            };

            _mockUserRepository.Setup(repo => repo.GetAll()).Returns(new List<User> { new User { Id = userId } }.AsQueryable());
            _mockUserRepository.Setup(repo => repo.GetAllUserDogs(userId)).Returns(new List<Dog>().AsQueryable());

            // Act
            var result = await _dogService.UpdateDogAsync(dogUpdateRequestModel);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("User does not own this dog", result.Errors);
        }

        [Fact]
        public async Task UpdateDogAsync_WithUpdatingDogFails_ReturnsError()
        {
            // Arrange
            var userId = "1";
            var dogUpdateRequestModel = new DogUpdateRequestModel
            {
                Id = 1,
                Name = "Buddy Updated",
                Race = "Labrador",
                Gender = "Male",
                DateOfBirth = new DateTime(2020, 1, 1),
                UserId = userId
            };
            var dog = new Dog { Id = dogUpdateRequestModel.Id };

            _mockUserRepository.Setup(repo => repo.GetAll()).Returns(new List<User> { new User { Id = userId } }.AsQueryable());
            _mockUserRepository.Setup(repo => repo.GetAllUserDogs(userId)).Returns(new List<Dog> { dog }.AsQueryable());
            _mockDogRepository.Setup(repo => repo.GetByIdAsync(dogUpdateRequestModel.Id)).ReturnsAsync(dog);
            _mockDogRepository.Setup(repo => repo.UpdateAsync(dog)).ReturnsAsync(false);

            // Act
            var result = await _dogService.UpdateDogAsync(dogUpdateRequestModel);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Dog update failed!", result.Errors);
        }

        [Fact]
        public async Task CheckIfExistsAsync_WithValidDogId_ReturnsTrue()
        {
            // Arrange
            var dogId = 1;

            _mockDogRepository.Setup(repo => repo.CheckIfExistsAsync(dogId)).ReturnsAsync(true);

            // Act
            var result = await _dogService.CheckIfExistsAsync(dogId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task CheckIfExistsAsync_WithInvalidDogId_ReturnsFalse()
        {
            // Arrange
            var dogId = 1;

            _mockDogRepository.Setup(repo => repo.CheckIfExistsAsync(dogId)).ReturnsAsync(false);

            // Act
            var result = await _dogService.CheckIfExistsAsync(dogId);

            // Assert
            Assert.False(result);
        }

    }
}
