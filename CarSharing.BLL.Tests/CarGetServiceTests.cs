using System;
using System.Threading.Tasks;
using CarSharing.BLL.Implementation;
using CarSharing.DataAccess.Contracts;
using CarSharing.Domain;
using CarSharing.Domain.Contracts;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace CarSharing.BLL.Tests
{
    public class CarGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_CarExists_DoesNothing()
        {
            // Arrange
            var departmentContainer = new Mock<ICarContainer>();

            var car = new Car();
            var carDataAccess = new Mock<ICarDataAccess>();
            carDataAccess.Setup(x => x.GetByAsync(departmentContainer.Object)).ReturnsAsync(car);

            var carGetService = new CarGetService(carDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => carGetService.ValidateAsync(departmentContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_CarNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var carContainer = new Mock<ICarContainer>();
            carContainer.Setup(x => x.CarId).Returns(id);

            var car = new Car();
            var carDataAccess = new Mock<ICarDataAccess>();
            carDataAccess.Setup(x => x.GetByAsync(carContainer.Object)).ReturnsAsync((Car)null);

            var carGetService = new CarGetService(carDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => carGetService.ValidateAsync(carContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Car not found by id {id}");
        }
    }
}