using BookRate.BLL.Services;
using BookRate.DAL.DTO.Contributor;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookRate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContributorController : ControllerBase
    {
        private readonly ContributorService _service;
        private IValidator<BaseContributorDTO> _validator;
        
        public ContributorController(ContributorService service, IValidator<BaseContributorDTO> validator)
        {
            _service = service;
            _validator = validator;
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
            ValidationResult result = await _validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                if (await _service.AddAsync(dto) > 0)
                    return StatusCode(StatusCodes.Status201Created, "Created successfully!");
            }
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateContributorDTO dto)
        {
            ValidationResult result = await _validator.ValidateAsync(dto);
            if (!result.IsValid)
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
