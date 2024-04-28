using NUnit.Framework;
using Moq;
using System.Threading.Tasks;

[TestFixture]
public class EmailServiceTests
{
    private EmailService _emailService;
    private Mock<IMailjetClient> _mockMailjetClient;

    [SetUp]
    public void Setup()
    {
        // Initialisation du service avec des clés fictives et une adresse e-mail expéditeur fictive
        _emailService = new EmailService("fake_api_key", "fake_api_secret", "sender@example.com");

        // Création d'un Mock pour IMailjetClient (interface utilisée par EmailService)
        _mockMailjetClient = new Mock<IMailjetClient>();
    }

    [Test]
    public async Task SendEmailAsync_Successful()
    {
        // Arrange
        string recipientEmail = "recipient@example.com";
        string subject = "Test Subject";
        string body = "Test Body";

        // Configuration du Mock pour simuler un envoi réussi
        _mockMailjetClient.Setup(client => client.PostAsync(It.IsAny
        <MailjetRequest>()))
            .ReturnsAsync(new MailjetResponse
            {
                IsSuccessStatusCode = true
            });

        // Injection du Mock dans le service d'email
        _emailService.MailjetClient = _mockMailjetClient.Object;

        // Act
        await _emailService.SendEmailAsync(recipientEmail, subject, body);

        // Assert
        // Vérification que le Mock a été appelé avec les paramètres attendus
        _mockMailjetClient.Verify(client => client.PostAsync(It.IsAny
    <MailjetRequest>()), Times.Once);
}

[Test]
public async Task SendEmailAsync_Failure()
{
    // Arrange
    string recipientEmail = "recipient@example.com";
    string subject = "Test Subject";
    string body = "Test Body";

    // Configuration du Mock pour simuler un échec d'envoi
    _mockMailjetClient.Setup(client => client.PostAsync(It.IsAny
        <MailjetRequest>()))
            .ReturnsAsync(new MailjetResponse
            {
                IsSuccessStatusCode = false,
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                ErrorInfo = new JObject(),
                ErrorMessage = "Failed to send email"
            });

        // Injection du Mock dans le service d'email
        _emailService.MailjetClient = _mockMailjetClient.Object;

        // Act & Assert
        // Vérifie que l'envoi d'email lance bien une exception
        Assert.ThrowsAsync<ApplicationException>(async () => await _emailService.SendEmailAsync(recipientEmail, subject, body));
    }
}
