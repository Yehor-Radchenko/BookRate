using BookRate.BLL.Services.IService;
using BookRate.DAL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BookRate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContributorController : Controller
    {
        private readonly IContributorService _service;

        public ContributorController(IContributorService service)
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
            var contributor = await _service.GetById(Id);
            return Ok(contributor);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateContributorDTO dto)
        {
            if (await _service.Add(dto))
                return Ok("Successfully created");
            else return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateContributorDTO dto)
        {
            if (await _service.Update(dto))
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
