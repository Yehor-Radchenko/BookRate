using AutoMapper;
using BookRate.BLL.ViewModels.Genre;
using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;
using BookRate.DAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.BLL.Services
{
    public class GenreService :GenericRepository<Genre>
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public GenreService(BookRateDbContext bookRateDbContext, 
            IUnitOfWork unitOfWork, 
            IMapper mapper)  : base(bookRateDbContext)                     
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreListModel>> GetDescriptionByGenreAsync(string genreName)
        {
            var movieRepository = _unitOfWork.GetRepository<Genre>();
            var list = await movieRepository.GetAllAsync(e => e.Name == genreName);

            var getMappedList = _mapper.Map<IEnumerable<GenreListModel>>(list);

            return getMappedList;
        }

    }
}
