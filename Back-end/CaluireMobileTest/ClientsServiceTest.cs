using Xunit;
using Moq;
using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.Services;
using System;
using CaluireMobile._0.Models.IService;
using Microsoft.EntityFrameworkCore;
namespace CaluireMobileTest
{
    public class ClientsServiceTests
    {
        private Mock<ICaluireMobileContext> _mockContext;
        private ClientsService _clientsService;

        public ClientsServiceTests()
        {
            _mockContext = new Mock<ICaluireMobileContext>();
            _clientsService = new ClientsService(_mockContext.Object);
        }

        [Fact]
        public void AddClient_NullClient_ThrowsArgumentNullException()
        {
            // Arrange
            Client client = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _clientsService.AddClient(client));
        }

        [Fact]
        public void AddClient_ValidClient_AddsClientToContext()
        {
            // Arrange
            var client = new Client();
            var mockSet = new Mock<DbSet<Client>>();
            _mockContext.Setup(c => c.Clients).Returns(mockSet.Object);

            // Act
            _clientsService.AddClient(client);

            // Assert
            mockSet.Verify(m => m.Add(It.IsAny<Client>()), Times.Once());
            _mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        [Fact]
        public void DeleteClient_NonExistingClient_ThrowsArgumentNullException()
        {
            // Arrange
            _mockContext.Setup(c => c.Clients.Find(It.IsAny<int>())).Returns((Client)null);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _clientsService.DeleteClient(1));
        }

        [Fact]
        public void DeleteClient_ExistingClient_RemovesClientFromContext()
        {
            // Arrange
            var client = new Client();
            _mockContext.Setup(c => c.Clients.Find(It.IsAny<int>())).Returns(client);

            // Act
            _clientsService.DeleteClient(1);

            // Assert
            _mockContext.Verify(c => c.Clients.Remove(client), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

    }
}
