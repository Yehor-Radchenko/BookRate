using BookRate.BLL.Services;
using BookRate.DAL.DTO.Contributor;
using Microsoft.AspNetCore.Http;
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
          
            return Ok( await _service.GetContributorListModelsAsync());
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
        public async Task<IActionResult> Post([FromBody] CreateContributorDTO dto)
        {
            if (await _service.AddAsync(dto))
                return Ok("Successfully created");
            else return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateContributorDTO dto)
        {
            if (await _service.UpdateAsync(dto))
                return Ok("Updated successfully.");
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (await _service.Delete(id))
                return Ok("Deleted successfully.");
            return BadRequest();
        }
    }
}
