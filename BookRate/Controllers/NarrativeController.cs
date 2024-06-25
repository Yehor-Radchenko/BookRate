using BookRate.BLL.Services;
using BookRate.DAL.DTO.Narrative;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BookRate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NarrativeController : Controller
    {
        private readonly NarrativeService _service;
        public NarrativeController(NarrativeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetListModels()
        {
            return Ok(await _service.GetNarrativeListModelsAsync());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var category = await _service.GetByIdAsync(Id);

            if (category == null)
            {
                throw new Exception("There is no such entity");
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NarrativeDto dto)
        {
            if (await _service.AddAsync(dto) > 0)
                return StatusCode(StatusCodes.Status201Created, "Created successfully!");
            return BadRequest();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int id, [FromBody] NarrativeDto dto)
        {
            if (await _service.UpdateAsync(id, dto))
                return StatusCode(StatusCodes.Status200OK, "Updated successfully.");
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (await _service.DeleteAsync(id))
                return StatusCode(StatusCodes.Status200OK, "Deleted successfully.");
            return BadRequest();
        }
    }
}
