using BookRate.Service.Models;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Mailjet.Client.TransactionalEmails;
using Mailjet.Client.TransactionalEmails.Response;
using Newtonsoft.Json.Linq;
using System.Text;

public class EmailService
{
    private readonly string _apiKey;
    private readonly string _apiSecret;
    public EmailService(string apiKey, string apiSecret)
    {
        _apiKey = apiKey;
        _apiSecret = apiSecret;
    }

    public async Task SendEmailAsync(EmailModel emailModel)
    {
        MailjetClient client = new MailjetClient(_apiKey, _apiSecret)
        {
            BaseAdress = "https://api.mailjet.com",
        };

        var email = new TransactionalEmailBuilder()
                .WithFrom(new SendContact(emailModel.From))
                .WithSubject(emailModel.Subject)
                .WithHtmlPart(emailModel.Body)
                .WithTo(new SendContact(emailModel.To))
                .Build();

        var response = await client.SendTransactionalEmailAsync(email);
        StringBuilder stringBuilder = new StringBuilder();

        foreach (var message in response.Messages)
        {
            if (message.Errors is not null)
            {
                foreach (var error in message.Errors)
                {
                    stringBuilder.AppendLine("Code: " + error.ErrorCode + "Message: " + error.ErrorMessage);
                }

                throw new Exception("MailJet error:" + stringBuilder.ToString());
            }
        }
    }
}
