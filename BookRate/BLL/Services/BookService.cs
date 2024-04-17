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

        public BookService(BookRateDbContext context)
        {
            _context = context;
        } 
        public async Task<bool> Create(BookDTO model)
        {
            throw new NotImplementedException();
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
