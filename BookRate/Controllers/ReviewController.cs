using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.Review;
using BookRate.DAL.DTO.Review;
using Microsoft.AspNetCore.Mvc;

namespace BookRate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService _reviewService;

        public ReviewController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetailReviewViewModel>> Get(int id)
        {
            var review = await _reviewService.GetReviewAsync(id);

            return Ok(review);
        }

        [HttpPost]
        // Don`t touch -  [ServiceFilter(typeof(CheckApproachFilter))]
        public async Task<ActionResult<int>> Post(ReviewDto reviewDto)
        {
            var review = await _reviewService.PostAsync(reviewDto);

            return Ok(review);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int reviewId, UpdateReviewDto reviewDto)
        {
            var result = await _reviewService.PutAsync(reviewId, reviewDto);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ReviewViewModel>>> GetReviews(int id)
        {
            var result = await _reviewService.GetReviewsAsync(id);

            return Ok(result);
        }

     

    }
}
