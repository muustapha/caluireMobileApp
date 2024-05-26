using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.IService;
using CaluireMobile._0.Models.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CaluireMobileTest
{

    public class EmployesServiceTests
    {
        private Mock<ICaluireMobileContext> _mockContext;
        private EmployesService _employesService;

        public EmployesServiceTests()
        {
            _mockContext = new Mock<ICaluireMobileContext>();
            _employesService = new EmployesService(_mockContext.Object);
        }

        [Fact]
        public void AddEmploye_NullEmploye_ThrowsArgumentNullException()
        {
            // Arrange
            Employe employe = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _employesService.AddEmploye(employe));
        }

        [Fact]
        public void AddEmploye_ValidEmploye_AddsEmployeToContext()
        {
            // Arrange
            var employe = new Employe();
            var mockSet = new Mock<DbSet<Employe>>();
            _mockContext.Setup(x => x.Employes).Returns(mockSet.Object);

            // Act
            _employesService.AddEmploye(employe);

            // Assert
            mockSet.Verify(m => m.Add(It.IsAny<Employe>()), Times.Once());
            _mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        [Fact]
        public void DeleteEmploye_NonExistingEmploye_ThrowsArgumentNullException()
        {
            // Arrange
            _mockContext.Setup(c => c.Employes.Find(It.IsAny<int>())).Returns((Employe)null);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _employesService.DeleteEmploye(1));
        }

        [Fact]
        public void DeleteEmploye_ExistingEmploye_RemovesEmployeFromContext()
        {
            // Arrange
            var employe = new Employe();
            _mockContext.Setup(c => c.Employes.Find(It.IsAny<int>())).Returns(employe);

            // Act
            _employesService.DeleteEmploye(1);

            // Assert
            _mockContext.Verify(c => c.Employes.Remove(employe), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }
    }

}
