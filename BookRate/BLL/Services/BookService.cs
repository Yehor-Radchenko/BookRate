using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;

namespace BookRate.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly Repository<Book> _bookRepository;
        private readonly IMapper _mapper;
        public BookService(Repository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        } 
        public Task<bool> Create(BookDTO model)
        {
            
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
