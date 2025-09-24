using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using MimeKit.Text;
using System.Configuration;

namespace Book_Shop.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            // create message
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse("aartemchelyk@gmail.com"));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html) { Text = htmlMessage };

            // send email
            using var smtp = new SmtpClient();

            await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync("aartemchelyk@gmail.com", "odpcnermgvgiyinx ");
            await smtp.SendAsync(message);
            await smtp.DisconnectAsync(true);
        }
    }
}