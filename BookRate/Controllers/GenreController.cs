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
        private IValidator<BaseGenreDTO> _validator;

        public GenreController(GenreService service, IValidator<BaseGenreDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetListModels()
        {
            return Ok(await _service.GetGenreListModelsAsync());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var category = await _service.GetByIdAsync(Id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateGenreDTO dto)
        {
            ValidationResult result = await _validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                if (await _service.AddAsync(dto) > 0)
                    return StatusCode(StatusCodes.Status201Created, "Created successfully!");
            }
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateGenreDTO dto)
        {
            ValidationResult result = await _validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                if (await _service.UpdateAsync(dto))
                    return StatusCode(StatusCodes.Status200OK, "Updated successfully.");
            }
            return BadRequest();
        }

        [HttpDelete("TestEmail")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (await _service.Delete(id))
                return StatusCode(StatusCodes.Status200OK, "Deleted successfully.");
            return BadRequest();
        }
    }
}
