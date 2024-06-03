using Xunit;
using Moq;
using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.Services;
using System;
using System.Threading.Tasks;
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
        public async Task AddClient_NullClient_ThrowsArgumentNullException()
        {
            // Arrange
            Client client = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _clientsService.AddClientAsync(client));
        }

        [Fact]
        public async Task AddClient_ValidClient_AddsClientToContext()
        {
            // Arrange
            var client = new Client();
            var mockSet = new Mock<DbSet<Client>>();
            _mockContext.Setup(c => c.Clients).Returns(mockSet.Object);
            _mockContext.Setup(c => c.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            await _clientsService.AddClientAsync(client);

            // Assert
            mockSet.Verify(m => m.AddAsync(It.IsAny<Client>(), It.IsAny<CancellationToken>()), Times.Once());
            _mockContext.Verify(c => c.SaveChangesAsync(), Times.Once());
        }

        [Fact]
        public async Task DeleteClient_NonExistingClient_ThrowsKeyNotFoundException()
        {
            // Arrange
            _mockContext.Setup(c => c.Clients.FindAsync(It.IsAny<int>())).ReturnsAsync((Client)null);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _clientsService.DeleteClientAsync(1));
        }

        [Fact]
        public async Task DeleteClient_ExistingClient_RemovesClientFromContext()
        {
            // Arrange
            var client = new Client();
            _mockContext.Setup(c => c.Clients.FindAsync(It.IsAny<int>())).ReturnsAsync(client);
            _mockContext.Setup(c => c.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            await _clientsService.DeleteClientAsync(1);

            // Assert
            _mockContext.Verify(c => c.Clients.Remove(client), Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(), Times.Once);
        }
    }
}
