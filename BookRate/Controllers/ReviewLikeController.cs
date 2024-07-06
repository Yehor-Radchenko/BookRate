using BookRate.BLL.Services;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.DAL.DTO.ReviewLike;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookRate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewLikeController : ControllerBase
    {
        private readonly ReviewLikeService _reviewLikeService;

        public ReviewLikeController(ReviewLikeService reviewLikeService)
        {
            _reviewLikeService = reviewLikeService;
        }

        [HttpPost("like-review")]
        public async Task<IActionResult> LikeReview(ReviewLikeDto reviewLikeDto)
        {
            var result = await _reviewLikeService.LikeReviewAsync(reviewLikeDto);
            return Ok(result);
        }

        [HttpPost("remove-like")]
        public async Task<IActionResult> RemoveLike(RemoveLikeDto removeLikeDto)
        {
            var result = await _reviewLikeService.RemoveLikeAsync(removeLikeDto);
            return Ok(result);
        }


    }
}
