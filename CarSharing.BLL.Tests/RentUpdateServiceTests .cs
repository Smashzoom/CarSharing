using System;
using System.Threading.Tasks;
using CarSharing.BLL.Contracts;
using CarSharing.BLL.Implementation;
using CarSharing.DataAccess.Contracts;
using CarSharing.Domain;
using CarSharing.Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace CarSharing.BLL.Tests
{
    public class RentUpdateServiceTests
    {
        [Test]
        public async Task UpdateAsync_DepartmentValidationSucceed_CreatesRent()
        {
            // Arrange
            var rent = new RentUpdateModel();
            var expected = new Rent();
            
            var companyGetService = new Mock<ICompanyGetService>();
            companyGetService.Setup(x => x.ValidateAsync(rent));

            var carGetService = new Mock<ICarGetService>();
            carGetService.Setup(x => x.ValidateAsync(rent));

            var rentDataAccess = new Mock<IRentDataAccess>();
            rentDataAccess.Setup(x => x.UpdateAsync(rent)).ReturnsAsync(expected);
            
            var rentGetService = new RentUpdateService(rentDataAccess.Object, companyGetService.Object, carGetService.Object);
            
            // Act
            var result = await rentGetService.UpdateAsync(rent);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task UpdateAsync_CompanyValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var rent = new RentUpdateModel();
            var expected = fixture.Create<string>();
            
            var companyGetService = new Mock<ICompanyGetService>();
            companyGetService
                .Setup(x => x.ValidateAsync(rent))
                .Throws(new InvalidOperationException(expected));

            var carGetService = new Mock<ICarGetService>();
            carGetService.Setup(x => x.ValidateAsync(rent)).Throws(new InvalidOperationException(expected));

            
            var rentDataAccess = new Mock<IRentDataAccess>();

            var rentGetService = new RentUpdateService(rentDataAccess.Object, companyGetService.Object, carGetService.Object);
            
            // Act
            var action = new Func<Task>(() => rentGetService.UpdateAsync(rent));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            rentDataAccess.Verify(x => x.UpdateAsync(rent), Times.Never);
        }
    }
}