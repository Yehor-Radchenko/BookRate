using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services
{
    public class ReviewService : IReviewService
    {
        public Task<bool> Create(ReviewDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReviewViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ReviewViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ReviewDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
