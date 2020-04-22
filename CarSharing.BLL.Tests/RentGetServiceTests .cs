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
    public class RentGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_RentExists_DoesNothing()
        {
            // Arrange
            var rentContainer = new Mock<IRentContainer>();

            var rent = new Rent();
            var rentDataAccess = new Mock<IRentDataAccess>();
            rentDataAccess.Setup(x => x.GetByAsync(rentContainer.Object)).ReturnsAsync(rent);

            var rentGetService = new RentGetService(rentDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => rentGetService.ValidateAsync(rentContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_RentNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var rentContainer = new Mock<IRentContainer>();
            rentContainer.Setup(x => x.RentId).Returns(id);

            var rent = new Rent();
            var rentDataAccess = new Mock<IRentDataAccess>();
            rentDataAccess.Setup(x => x.GetByAsync(rentContainer.Object)).ReturnsAsync((Rent)null);

            var rentGetService = new RentGetService(rentDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => rentGetService.ValidateAsync(rentContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Rent not found by id {id}");
        }
    }
}