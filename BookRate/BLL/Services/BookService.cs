using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<bool> Add(CreateBookDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
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

        public Task<bool> Update(UpdateBookDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BookCardViewModel>> GetTopOfWeekBookCards()
        {
            var topBooks = await _bookRepository.GetTopOfWeekBooks();

            return topBooks.Select(tb => new BookCardViewModel
            {
                BookId = tb.Id,
                Title = tb.Title,
                Authors = tb.Narratives
                    .SelectMany(narrative => narrative.Contributors
                        .Where(contributor => contributor.Roles.Any(role => role.Name == "Author")))
                    .Select(author => $"{author.LastName} {author.FirstName} {author.Patronymic}")
                    .Distinct(),
                AverageRate = tb.Rates != null && tb.Rates.Any()
                    ? tb.Rates.Average(rate => rate.StarsRate)
                    : 0,
                Photo = tb.BookEditions.FirstOrDefault()?.Photo
            }).ToList();
        }
    }
}
