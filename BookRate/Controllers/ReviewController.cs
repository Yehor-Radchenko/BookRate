using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.Review;
using BookRate.DAL.DTO.Review;
using BookRate.Filters;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace BookRate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
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
            var review = await _reviewService.GetReviewAsync(id);

            return Ok(review);
        }



        [HttpPost]
        [ServiceFilter(typeof(CheckApproachFilter))]
        public async Task<ActionResult<ReviewViewModel>> Post(ReviewDto reviewDto)
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

        //[HttpGet]
        //public async Task<ActionResult<ReviewViewModel>> GetAll()
        //{

        //    var getToken = HttpContext.Request.Cookies["Token"];

        //    var convertToken = JwtSecurityTokenConverter.Convert(new Microsoft.IdentityModel.JsonWebTokens.JsonWebToken(getToken));

        //    var id = Convert.ToInt32(convertToken.Claims.FirstOrDefault().Value);

        //    var reviews = await _reviewService.GetReviewsAsync();

        //    return Ok(reviews);
        //}

    }
}
