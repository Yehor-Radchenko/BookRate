using BookRate.Service.Models;
using MailKit.Net.Smtp;
using MimeKit;
using static System.Net.Mime.MediaTypeNames;

namespace BookRate.Service.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("BookSpace", emailMessage.From));
            foreach (var to in emailMessage.To)
            {
                message.To.Add(new MailboxAddress("", to));
            }
            message.Subject = emailMessage.Subject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = emailMessage.Body };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync(emailMessage.From, "mvso befm imdl whmj"); // Use Google App password
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
    