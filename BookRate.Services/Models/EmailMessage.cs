using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.Service.Models
{
    public class EmailMessage
    {
        public List<string> To { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }
        public string From { get; private set; }

        public EmailMessage(List<string> to, string subject, string body, string from = "bookspace.info.notification@gmail.com")
        {
            To = to;
            Subject = subject;
            Body = body;
            From = from;
        }

        public EmailMessage(string to, string subject, string body, string from = "bookspace.info.notification@gmail.com")
        {
            To = [to];
            Subject = subject;
            Body = body;
            From = from;
        }
    }
}
