using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;

namespace BookRate.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly BookRateDbContext _context;
        private readonly IMapper _mapper;
        public BookService(BookRateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        } 
        public Task<bool> Create(BookDTO model)
        {
            if (model.Narratives is null)
                throw new Exception("Impossible to create a book without at least one narrative.");
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BookViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(BookDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
