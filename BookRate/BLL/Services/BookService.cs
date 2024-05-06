using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly INarrativeRepository _narrativeRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, 
            INarrativeRepository narrativeRepository, 
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _narrativeRepository = narrativeRepository;
        }

        public async Task<bool> Add(CreateBookDTO dto)
        {
            List<Narrative> selectedNarrativeModels= new List<Narrative>();

            foreach (var id in dto.NarrativesId)
            {
                Narrative model = await _narrativeRepository.GetByIdAsync(id);
                if (model is null)
                    throw new Exception($"Can't create Book: narrative with ID {id} not found.");
                else
                    selectedNarrativeModels.Add(model);
            }

            try
            {
                if(await _bookRepository.Add(_mapper.Map<Book>(dto)))
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _bookRepository.Delete(new Book { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
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
