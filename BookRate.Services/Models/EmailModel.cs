using System.Text.Json.Serialization;

namespace BookRate.Service.Models
{
    public class EmailModel
    {
        public string To { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }
        public string From { get; private set; } = "bookspace.info.notification@gmail.com";

        [JsonConstructor]
        public EmailModel(string to, string subject, string body, string? from = null)
        {
            To = to;
            Subject = subject;
            Body = body;
            From = from!;
        }
    }
}
