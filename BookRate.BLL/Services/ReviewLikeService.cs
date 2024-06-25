using BookRate.BLL.Exceptions;
using BookRate.DAL.DTO.ReviewLike;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;

namespace BookRate.BLL.Services
{
    public class ReviewLikeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewLikeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> LikeReviewAsync(ReviewLikeDto reviewLikeDto)
        {
            var reviewLikeRepo = _unitOfWork.GetRepository<ReviewLike>();

            var likeReview = new ReviewLike
            {
                DateLiked = DateTime.UtcNow,
                ReviewId = reviewLikeDto.ReviewId,
                UserId = reviewLikeDto.UserId,
                IsLiked = true,
            };

            await reviewLikeRepo.AddAsync(likeReview);
            await _unitOfWork.CommitAsync();

            return likeReview.ReviewId;

        }

        public async Task<int> RemoveLikeAsync(RemoveLikeDto removeLikeDto)
        {
            var reviewLikeRepo = _unitOfWork.GetRepository<ReviewLike>();

            var getLike = await reviewLikeRepo.GetAsync(e => e.UserId == removeLikeDto.UserId
                                                        && e.ReviewId == removeLikeDto.ReviewId) 
                ?? throw new NotFoundException("Like already remove");



            await reviewLikeRepo.DeleteAsync(getLike);
            await _unitOfWork.CommitAsync();

            return getLike.ReviewId;

        }


    }
}
