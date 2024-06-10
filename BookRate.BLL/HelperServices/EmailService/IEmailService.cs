using BookRate.Service.Models;

namespace BookRate.Service.Services
{
    internal interface IEmailService
    {
        Task SendEmailAsync(EmailModel emailMessage);
    }
}
