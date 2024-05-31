using BookRate.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.Service.Services
{
    internal interface IEmailService
    {
        Task SendEmailAsync(EmailMessage emailMessage);
    }
}
