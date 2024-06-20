using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.Review;
using BookRate.DAL.DTO.Review;
using Microsoft.AspNetCore.Mvc;

namespace BookRate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService _reviewService;

        public ReviewController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewViewModel>> Get(int id)
        {
            var review = await _reviewService.GetReviewsByUserIdAsync(id);


            return Ok(review);
        }

        [HttpPost]
        public async Task<ActionResult<ReviewViewModel>> Post(ReviewDto reviewDto)
        {
            var review = await _reviewService.PostAsync(reviewDto);

            return Ok(review);
        }

    }
}
