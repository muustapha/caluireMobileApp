namespace CaluireMobile._0.Models.IService
{
    public interface IEmailService
    {
        Task SendEmailAsync(string recipientEmail, string subject, string body);
    }
}
