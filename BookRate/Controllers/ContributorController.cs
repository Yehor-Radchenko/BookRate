using BookRate.BLL.Services;
using BookRate.DAL.DTO.Contributor;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookRate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContributorController : ControllerBase
    {
        private readonly ContributorService _service;

        public ContributorController(ContributorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetListModels()
        {
            return Ok(await _service.GetContributorListModelsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await _service.GetByIdAsync(id);

            if (category == null)
            {
                throw new Exception("There is no such entity");
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ContributorDto dto)
        {

            if (await _service.AddAsync(dto) > 0)
                return StatusCode(StatusCodes.Status201Created, "Created successfully!");
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] ContributorDto dto)
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
