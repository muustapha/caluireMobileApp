using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

public class EmailService
{
    private readonly string _mailjetApiKey; // Clé API Mailjet
    private readonly string _mailjetApiSecret; // Clé secrète API Mailjet
    private readonly string _senderEmailAddress; // Adresse e-mail de l'expéditeur
public EmailService(string mailjetApiKey, string mailjetApiSecret, string senderEmailAddress)
{
    _mailjetApiKey = mailjetApiKey ?? throw new ArgumentNullException(nameof(mailjetApiKey));
    _mailjetApiSecret = mailjetApiSecret ?? throw new ArgumentNullException(nameof(mailjetApiSecret));
    _senderEmailAddress = senderEmailAddress ?? throw new ArgumentNullException(nameof(senderEmailAddress));
   
   
}


public async Task SendEmailAsync(string recipientEmail, string subject, string body)
{
    try
    {
        MailjetClient client = new MailjetClient(_mailjetApiKey, _mailjetApiSecret);

        MailjetRequest request = new MailjetRequest
        {
            Resource = Send.Resource,
        }
        .Property(Send.Messages, new JArray {
            new JObject {
                {"From", new JObject {
                    {"Email", _senderEmailAddress},
                    {"Name", "Caluire Mobile"}
                }},
                {"To", new JArray {
                    new JObject {
                        {"Email", recipientEmail}
                    }
                }},
                {"Subject", subject},
                {"TextPart", body},
                {"HTMLPart", body}
            }
        });
        // Log avant l'envoi de l'email
        Console.WriteLine($"Sending email to {recipientEmail} with subject '{subject}'.");

        MailjetResponse response = await client.PostAsync(request);
        if (!response.IsSuccessStatusCode)
        {
              Console.WriteLine($"StatusCode: {response.StatusCode}");
            Console.WriteLine($"ErrorInfo: {response.GetErrorInfo()}");
            Console.WriteLine($"ErrorMessage: {response.GetErrorMessage()}");
            throw new ApplicationException($"Erreur lors de l'envoi de l'email: {response.StatusCode}");
        }
    }
    catch (Exception ex)
    {
         Console.WriteLine($"An error occurred while sending email: {ex.Message}");
        // Log the exception or handle it further up the stack
        throw new InvalidOperationException($"An error occurred while sending email: {ex.Message}", ex);
    }
}

}

