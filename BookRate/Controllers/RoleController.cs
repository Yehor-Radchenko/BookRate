﻿using BookRate.BLL.Services;
using BookRate.DAL.DTO.Role;
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
        public async Task<IActionResult> Post([FromBody] RoleDto dto)
        {
            if (await _service.AddAsync(dto) > 0)
                return StatusCode(StatusCodes.Status201Created, "Created successfully!");

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] RoleDto dto)
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
