using BookRate.BLL.Services;
using BookRate.DAL.DTO.Genre;
using BookRate.DAL.DTO.Role;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookRate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _service;

        public RoleController(RoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetRolesAsync());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var category = await _service.GetByIdAsync(Id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRoleDTO dto)
        {
            if (await _service.AddAsync(dto))
                return Ok("Successfully created");
            else return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateRoleDTO dto)
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
