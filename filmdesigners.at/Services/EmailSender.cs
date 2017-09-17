using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmdesigners.at.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage
            {
                From = new EmailAddress("noreply@filmdesigners.at", "VÖF"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            msg.AddTo(new EmailAddress(email));

            return client.SendEmailAsync(msg);
        }

        public Task SendRegisterMail(string email, string callBackUrl)
        {
            var mail = new SendGridMessage
            {
                From = new EmailAddress("noreply@filmdesigners.at", "VÖF"),
                Subject = "E-Mail-Adresse Bestätigen",
                PlainTextContent = string.Empty,
                HtmlContent = "<p></p>"
            };

            var client = new SendGridClient(Options.SendGridKey);
            
            mail.AddTo(new EmailAddress(email));
            mail.SetTemplateId("2a1d782e-aba5-4478-9b37-827e1f29696d");
            mail.AddSubstitution("-confirmationlink-", callBackUrl);

            return client.SendEmailAsync(mail);
        }
    }
}
