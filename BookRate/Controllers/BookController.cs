using BookRate.BLL.Services;
using BookRate.BLL.ViewModels.Book;
using BookRate.DAL.DTO.Book;
using Microsoft.AspNetCore.Mvc;

namespace BookRate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;
        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookViewModel>> Get(int id)
        {
            var result = await _bookService.GetAsync(id);

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(BookDto bookDto)
        {
            var result = await _bookService.AddAsync(bookDto);
            return Ok(result);
        }


        [HttpGet]
        public async Task<ActionResult<List<BookCardViewModel>>> GetAll()
        {
            var result = await _bookService.GetAllAsync();

            return Ok(result);
        }
    }
}
