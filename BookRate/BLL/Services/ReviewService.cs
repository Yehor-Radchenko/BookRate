﻿using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;

namespace BookRate.BLL.Services
{
    public class ReviewService : IReviewService
    {
        private readonly Repository<Review> _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewService(Repository<Review> reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

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
