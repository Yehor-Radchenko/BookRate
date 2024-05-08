using BookRate.BLL.Services.IService;
using BookRate.DAL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookRate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetTopOfWeekBookCards()
        {
            return Ok(await _service.GetTopOfWeekBookCards());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecificBookInfo([FromRoute] int id)
        {
            var book = await _service.GetSpecificBookInfo(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBookDTO dto)
        {
            if (await _service.Add(dto))
                return Ok("Successfully created");
            else return BadRequest();
        }
    }
}
