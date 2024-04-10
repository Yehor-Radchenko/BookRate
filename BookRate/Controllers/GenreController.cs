using BookRate.BLL.Services;
using BookRate.BLL.Services.IService;
using BookRate.DAL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BookRate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : Controller
    {
        private readonly IGenreService _service;

        public GenreController(IGenreService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var category = await _service.GetById(Id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> PostGenre([FromBody] CreateGenreDTO dto)
        {
            if (await _service.Add(dto))
                return Ok("Successfully created");
            else return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> PutGenre([FromBody] UpdateGenreDTO dto)
        {
            if (await _service.Update(dto))
                return Ok("Updated successfully.");
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre([FromRoute] int id)
        {
            if (await _service.Delete(id))
                return Ok("Deleted successfully.");
            return BadRequest();
        }
    }
}
