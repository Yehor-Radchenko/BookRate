using BookRate.BLL.Services;
using BookRate.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookRate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailSenderTestController : Controller
    {
        private readonly EmailService _emailService;

        public EmailSenderTestController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] EmailModel emailMessage) 
        {
            await _emailService.SendEmailAsync(emailMessage);
            return StatusCode(StatusCodes.Status200OK, "Sended successfully.");
        }
    }
}
