using Moq;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Repositories;
using PRI.Project.Rosseel_Almanzo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Tests
{
    public class ImageServiceTests
    {
        private readonly Mock<IImageRepository> _mockImageRepository;
        private readonly ImageService _imageService;

        public ImageServiceTests()
        {
            _mockImageRepository = new Mock<IImageRepository>();
            _imageService = new ImageService(_mockImageRepository.Object);
        }

        [Fact]
        public async Task DeleteImageAsync_WithValidImageId_ReturnsSuccesIsTrue()
        {
            // Arrange
            var imageId = 1;
            var image = new Image { Id = imageId };

            _mockImageRepository.Setup(repo => repo.GetByIdAsync(imageId)).ReturnsAsync(image);
            _mockImageRepository.Setup(repo => repo.DeleteAsync(image)).ReturnsAsync(true);

            // Act
            var result = await _imageService.DeleteImageAsync(imageId);

            // Assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task DeleteImageAsync_ImageDoesNotExist_ReturnsError()
        {
            // Arrange
            var imageId = 1;

            _mockImageRepository.Setup(repo => repo.GetByIdAsync(imageId)).ReturnsAsync((Image)null);

            // Act
            var result = await _imageService.DeleteImageAsync(imageId);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Image does not exist!", result.Errors);
        }

        [Fact]
        public async Task DeleteImageAsync_WithRepoResultIsFalse_ReturnsError()
        {
            // Arrange
            var imageId = 1;
            var image = new Image { Id = imageId };

            _mockImageRepository.Setup(repo => repo.GetByIdAsync(imageId)).ReturnsAsync(image);
            _mockImageRepository.Setup(repo => repo.DeleteAsync(image)).ReturnsAsync(false);

            // Act
            var result = await _imageService.DeleteImageAsync(imageId);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("Image not deleted!", result.Errors);
        }

        [Fact]
        public async Task GetByIdAsync_WithValidImageId_ReturnsImage()
        {
            // Arrange
            var imageId = 1;
            var image = new Image { Id = imageId };

            _mockImageRepository.Setup(repo => repo.GetByIdAsync(imageId)).ReturnsAsync(image);

            // Act
            var result = await _imageService.GetByIdAsync(imageId);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(imageId, result.Value.Id);
        }

        [Fact]
        public async Task GetByIdAsync_WithInValidImageId_ReturnsError()
        {
            // Arrange
            var imageId = 1;

            _mockImageRepository.Setup(repo => repo.GetByIdAsync(imageId)).ReturnsAsync((Image)null);

            // Act
            var result = await _imageService.GetByIdAsync(imageId);

            // Assert
            Assert.False(result.Success);
            Assert.Contains("No image found", result.Errors);
        }
    }
}
