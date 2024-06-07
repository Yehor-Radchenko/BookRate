using BookRate.BLL.Services;
using BookRate.DAL.DTO.Contributor;
using BookRate.DAL.DTO.Genre;
using BookRate.Service.Models;
using BookRate.Service.Services;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Sprache;

namespace BookRate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : Controller
    {
        private readonly GenreService _service;

        public GenreController(GenreService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetListModels()
        {
            return Ok(await _service.GetGenreListModelsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await _service.GetByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GenreDto dto)
        {
            
            if (await _service.AddAsync(dto) > 0)
                return StatusCode(StatusCodes.Status201Created, "Created successfully!");
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] GenreDto dto)
        {
            
            if (await _service.UpdateAsync(id, dto))
                return StatusCode(StatusCodes.Status200OK, "Updated successfully.");
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (await _service.Delete(id))
                return StatusCode(StatusCodes.Status200OK, "Deleted successfully.");
            return BadRequest();
        }
    }
}
