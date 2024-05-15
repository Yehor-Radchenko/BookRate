﻿using BookRate.BLL.Services;
using BookRate.DAL.DTO.Genre;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var category = await _service.GetByIdAsync(Id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateGenreDTO dto)
        {
            if (await _service.AddAsync(dto))
                return Ok("Successfully created");
            else return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateGenreDTO dto)
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
