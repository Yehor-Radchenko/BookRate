using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels.Book;
using BookRate.DAL.DTO.Book;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly INarrativeRepository _narrativeRepository;
        private readonly IBookEditionRepository _bookEditionRepository;
        private readonly IEditionRepository _editionRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, 
            INarrativeRepository narrativeRepository, 
            IBookEditionRepository bookEditionRepository,
            IEditionRepository editionRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _narrativeRepository = narrativeRepository;
            _bookEditionRepository = bookEditionRepository;
            _editionRepository = editionRepository;
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
                int addedBookId = await _bookRepository.Add(_mapper.Map<Book>(dto));

                if (addedBookId > 0 && _editionRepository.IsEditionWithIdExists(dto.createBookEditionDTO.EditionId))
                {
                    var bookEditionModel = _mapper.Map<BookEdition>(dto.createBookEditionDTO);
                    bookEditionModel.BookId = addedBookId;
                    await _bookEditionRepository.Add(bookEditionModel);
                }
                return true;
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

        public async Task<BookViewModel?> GetSpecificBookInfo(int? id)
        {
            try
            {
                if (id == null)
                    throw new Exception("Id is null.");

                BookEdition? bookEditionModel = await _bookRepository.GetSpecificBookInfoAsync(id.Value);

                if (bookEditionModel == null)
                    throw new Exception($"There is no book with Id {id}");

                return _mapper.Map<BookViewModel>(bookEditionModel);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving specific book.", ex);
            }
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
