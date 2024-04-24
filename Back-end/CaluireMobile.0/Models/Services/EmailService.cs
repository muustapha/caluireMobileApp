using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace CaluireMobile._0.Models.Services
{
    public class EmailService 
    {
        private readonly string _sendGridApiKey; // Clé API SendGrid
        private readonly string _senderEmailAddress; // Adresse e-mail de l'expéditeur

        public EmailService(string sendGridApiKey, string senderEmailAddress)
        {
            _sendGridApiKey = sendGridApiKey;
            _senderEmailAddress = senderEmailAddress;
        }

        public async Task SendEmailAsync(string emailAddress, string subject, string body)
        {
            // Créez un client SendGrid en utilisant votre clé API
            var client = new SendGridClient(_sendGridApiKey);

            // Créez le message e-mail
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(_senderEmailAddress, "Votre application"),
                Subject = subject,
                PlainTextContent = body,
                HtmlContent = body
            };

            // Ajoutez le destinataire
            msg.AddTo(new EmailAddress(emailAddress));

            // Envoyez l'e-mail
            var response = await client.SendEmailAsync(msg);

            if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                // Gestion des erreurs d'envoi d'e-mail
                throw new ApplicationException($"Erreur lors de l'envoi de l'e-mail : {response.StatusCode}");
            }
        }
    }
}
