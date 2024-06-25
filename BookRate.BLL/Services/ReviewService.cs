using AutoMapper;
using BookRate.BLL.Exceptions;
using BookRate.BLL.ViewModels.Review;
using BookRate.DAL.DTO.Review;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
using BookRate.Validation;
using FluentValidation;

namespace BookRate.BLL.Services.ServiceAbstraction
{
    public class ReviewService : BaseService<Review, ReviewDto>
    {
        public ReviewService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IValidator<ReviewDto> validator)
            : base(unitOfWork, mapper, validator)
        { }

        public async Task<int> PostAsync(ReviewDto reviewDto)
        {
            var reviewRepo = _unitOfWork.GetRepository<Review>();
            var rateRepo = _unitOfWork.GetRepository<Rate>();

            var validate = new ReviewValidator();
            var result = await validate.ValidateAsync(reviewDto);

            if (!result.IsValid)
            {
                throw new BadRequestException("Something went wrong", result.ToDictionary());
            }

            var newReview = new Review
            {
                Title = reviewDto.Title,
                Text = reviewDto.Text,

                DatePosted = reviewDto.DatePosted,
                StartReadDate = reviewDto.StartReadDate,
                EndReadDate = reviewDto.EndReadDate,

                RateId = reviewDto.RateId,
                UserId = reviewDto.UserId,
                BookId = reviewDto.BookId,
            };

            if (reviewDto.RateId == 0)
            {
                var rate = new Rate
                {
                    UserId = reviewDto.UserId,
                    BookId = reviewDto.BookId,
                    DateRated = reviewDto.DatePosted,
                    StarsRate = reviewDto.RateStarts,
                };

                var isAdd = await rateRepo.AddAsync(rate);
                await _unitOfWork.CommitAsync();
                var getLastRate = await rateRepo.GetAsync(e => e.DateRated == reviewDto.DatePosted
                                                                  && e.UserId == reviewDto.UserId);

                if (isAdd)
                {
                    newReview.RateId = getLastRate.Id;
                }

            }

            await reviewRepo.AddAsync(newReview);
            await _unitOfWork.CommitAsync();

            return newReview.Id;
        }
        public async Task<int> PutAsync(int reviewId, UpdateReviewDto reviewDto)
        {
            var reviewRepo = _unitOfWork.GetRepository<Review>();

            var getReview = await reviewRepo.GetAsync(e => e.Id == reviewId, includeOptions: "User,Book,Rate");

            if (getReview == null)
                throw new NotFoundException("Something went wrong", $"{reviewId}");

            getReview.Title = reviewDto.Title;
            getReview.Text = reviewDto.Text;
            getReview.DateUpdated = reviewDto.DateUpdate;
            getReview.StartReadDate = reviewDto.StartReadDate;
            getReview.EndReadDate = reviewDto.EndReadDate;
            getReview.IsChanged = true;

            getReview.Rate.StarsRate = reviewDto.RateStarts;

            await reviewRepo.UpdateAsync(getReview);
            await _unitOfWork.CommitAsync();

            return getReview.Id;
        }
        public async Task<DetailReviewViewModel> GetReviewAsync(int id)
        {
            var reviewRepo = _unitOfWork.GetRepository<Review>();
            var getUserRepo = _unitOfWork.GetRepository<User>();

            var getReview = await reviewRepo.GetAsync(e => e.Id == id,
                                                includeOptions: "Commentaries,ReviewLikes,Book,User,Rate");

            var reviewModel = new DetailReviewViewModel
            {
                Title = getReview.Title,
                Text = getReview.Text,
                DatePosted = getReview.DatePosted,
                StartReadDate = getReview.StartReadDate,
                EndReadDate = getReview.EndReadDate,
                UserId = id,
                Username = getReview.User.Username,
                BookId = getReview.BookId,
                BookName = getReview.Book.Title,
                NumberOfLikes = getReview.ReviewLikes.Count(),
            };

            return reviewModel;
        }
        public async Task<List<ReviewViewModel>> GetReviewsAsync(int id)
        {
            var reviewRepo = _unitOfWork.GetRepository<Review>();

            var reviews = await reviewRepo.GetAllAsync(e => e.UserId == id, includeOptions: "Book,Rate,User,ReviewLikes");


            var reviewList = new List<ReviewViewModel>();

            foreach (var review in reviews)
            {
                reviewList.Add(new ReviewViewModel
                {
                    Id = review.Id,
                    Title = review.Title,
                    Text = review.Text,
                    DatePosted = review.DatePosted,
                    BookTitle = review.Book.Title,

                    Username = review.User.Username,
                    NumberOfLikes = review.ReviewLikes.Count(),
                });
            }

            return reviewList;
        }

    }
}
