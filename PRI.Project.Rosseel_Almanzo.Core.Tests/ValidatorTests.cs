using Microsoft.EntityFrameworkCore.Storage;
using PRI.Project.Rosseel_Almanzo.Api.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Tests
{
    public class ValidatorTests
    {
        public static IEnumerable<object[]> ValidDates =>
            new List<object[]>
            {
                new object[] { DateTime.Now.AddDays(1) },
                new object[] { DateTime.Now.AddDays(10) }
            };

        public static IEnumerable<object[]> InValidDates =>
            new List<object[]>
            {
                new object[] { DateTime.Now.AddDays(-1) },
                new object[] { DateTime.Now.AddMinutes(-10) }
            };

        [Theory]
        [MemberData(nameof(ValidDates))]
        public void IsValid_WithDateIsGreaterThenDateTimeNow_ReturnsTrue(DateTime validDate)
        {
            // Arrange
            var validator = new EventDateValidator();

            // Act
            var result = validator.IsValid(validDate);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(InValidDates))]
        public void IsValid_WithDateIsLesserThenDateTimeNow_ReturnsFalse(DateTime inValidDate)
        {
            // Arrange
            var validator = new EventDateValidator();

            // Act
            var result = validator.IsValid(inValidDate);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValid_WithDateIsLesserThenDateTimeNow_ReturnsTrue()
        {
            // Arrange
            var validator = new UserDateValidator();
            var validDate = DateTime.Now.AddDays(-1);

            // Act
            var result = validator.IsValid(validDate);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsValid_WithDateIsGreaterThenDateTimeNow_ReturnsFalse()
        {
            // Arrange
            var validator = new UserDateValidator();
            var inValidDate = DateTime.Now.AddDays(1);

            // Act
            var result = validator.IsValid(inValidDate);

            // Assert
            Assert.False(result);
        }
    }
}
