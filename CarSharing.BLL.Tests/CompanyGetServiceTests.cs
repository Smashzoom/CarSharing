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
    public class CompanyGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_CompanyExists_DoesNothing()
        {
            // Arrange
            var companyContainer = new Mock<ICompanyContainer>();

            var company = new Company();
            var companyDataAccess = new Mock<ICompanyDataAccess>();
            companyDataAccess.Setup(x => x.GetByAsync(companyContainer.Object)).ReturnsAsync(company);

            var companyGetService = new CompanyGetService(companyDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => companyGetService.ValidateAsync(companyContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_CompanyNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var companyContainer = new Mock<ICompanyContainer>();
            companyContainer.Setup(x => x.CompanyId).Returns(id);

            var company = new Company();
            var companyDataAccess = new Mock<ICompanyDataAccess>();
            companyDataAccess.Setup(x => x.GetByAsync(companyContainer.Object)).ReturnsAsync((Company)null);

            var companyGetService = new CompanyGetService(companyDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => companyGetService.ValidateAsync(companyContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Company not found by id {id}");
        }
    }
}