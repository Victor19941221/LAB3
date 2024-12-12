using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;

namespace Lab3.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var ForEmail = "";
            var FromPassword = "";

            var message = new MailMessage();
            message.From = new MailAddress(ForEmail);
            message.Subject = subject;
            message.Body = htmlMessage;
            message.IsBodyHtml = true;
            message.To.Add(email);

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(ForEmail, FromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(message);

        }
    }
}
