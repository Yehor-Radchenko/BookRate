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
        private IValidator<BaseNarrativeDTO> _validator;

        public NarrativeController(NarrativeService service, IValidator<BaseNarrativeDTO> validator)
        {
            _service = service;
            _validator = validator;
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
        public async Task<IActionResult> Post([FromBody] CreateNarrativeDTO dto)
        {
            ValidationResult result = await _validator.ValidateAsync(dto);
            if (result.IsValid)
            {
                if (await _service.AddAsync(dto) > 0)
                    return StatusCode(StatusCodes.Status201Created, "Created successfully!");
            }
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateNarrativeDTO dto)
        {
            ValidationResult result = await _validator.ValidateAsync(dto);
            if (result.IsValid)
            {
                if (await _service.UpdateAsync(dto))
                    return StatusCode(StatusCodes.Status200OK, "Updated successfully.");
            }
            return BadRequest(result);
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
