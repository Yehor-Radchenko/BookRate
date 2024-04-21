using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;

namespace BookRate.BLL.Services
{
    public class ReviewService : IReviewService
    {
        private readonly BookRateDbContext _context;
        private readonly IMapper _mapper;

        public ReviewService(BookRateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> Create(UpdateReviewDTO model)
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

        public Task<bool> Update(UpdateReviewDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
