using AutoMapper;
using BookRate.BLL.Exceptions;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.Book;
using BookRate.BLL.ViewModels.BookEdition;
using BookRate.BLL.ViewModels.Narrative;
using BookRate.DAL.DTO.Book;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
using BookRate.Validation;
using FluentValidation;

namespace BookRate.BLL.Services
{
    public class BookService : BaseService<Book, BookDto>, IService<BookDto>
    {
        public BookService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<BookDto> validator) : base(unitOfWork, mapper, validator)
        { }


        public async Task<BookViewModel> GetAsync(int id)
        {
            var bookRepo = _unitOfWork.GetRepository<Book>();
            var bookEditionRepo = _unitOfWork.GetRepository<BookEdition>();

            var getBook = await bookRepo.GetAsync(e => e.Id == id,
                includeOptions: "BookEditions,Rates,Reviews,Narratives,Shelves,Serie");

            var bookEdition = await bookEditionRepo.GetAsync(e => e.BookId == id, includeOptions: "Edition,Book");

            if (getBook == null)
                throw new NotFoundException("", $"{id}");

            var infoAboutBook = new BookViewModel
            {
                Id = id,
                Title = getBook.Title,
                FirstPublished = getBook.FirstPublished,
                AverageRate = getBook.Rates.Any() ? getBook.Rates.Average(e => e.StarsRate) : 0,
                SerieId = getBook.SerieId,
                SerieName = getBook.Serie?.Name,
                BookEdition = _mapper.Map<BookEditionViewModel>(bookEdition),
                Narratives = _mapper.Map<List<NarrativeViewModel>>(getBook.Narratives)
            };

            infoAboutBook.BookEdition.EditionName = bookEdition.Edition.Name;
            infoAboutBook.BookEdition.CoverType = bookEdition.CoverType.ToString();

            return infoAboutBook;
        }
        public async Task<List<BookCardViewModel>> GetAllAsync()
        {
            var bookRepo = _unitOfWork.GetRepository<Book>();
            var bookEditionRepo = _unitOfWork.GetRepository<BookEdition>();
            var narrativeRepo = _unitOfWork.GetRepository<Narrative>();


            var books = new List<BookCardViewModel>();

            var bookList = await bookEditionRepo.GetAllAsync(includeOptions: "Book,Edition");

            var authors = await narrativeRepo.GetAllAsync(includeOptions: "NarrativeContributorRoles");

            //foreach (var book in bookList)
            //{
            //    books.Add(new BookCardViewModel
            //    {
            //        BookId = book.BookId,
            //        AverageRate = book.Book.Rates.Any() ? book.Book.Rates.Average(e => e.StarsRate) : 0,
            //        EditionName = book.Edition.Name,
            //        Title = book.Book.Title,
            //        Authors = { authors.FirstOrDefault(e => e.Title == book.Book.Title).NarrativeContributorRoles.},
            //    });
            //}

            return books;
        }

        public async Task<int> AddAsync(BookDto dto)
        {
            var bookRepo = _unitOfWork.GetRepository<Book>();
            var narrativeRepo = _unitOfWork.GetRepository<Narrative>();

            var validation = new BookValidator();
            var result = await validation.ValidateAsync(dto);

            if (!result.IsValid)
                throw new BadRequestException("Something went wrong", result.ToDictionary());

            var newBook = new Book
            {
                SerieId = dto.SerieId,
                Title = dto.Title,
                FirstPublished = dto.FirstPublished,
                Narratives = {new Narrative
                {
                    Title = dto.Narrative.Title,
                    Description = dto.Narrative.Description,
                    OriginalTitle = dto.Narrative.OriginalTitle,
                    ThreeLetterIsolanguageName = dto.Narrative.ThreeLetterIsolanguageName,
                } }



            };

            await bookRepo.AddAsync(newBook);

            var bookEdition = new BookEdition
            {
                BookId = dto.BookEditionDTO.BookId,
                EditionId = dto.BookEditionDTO.EditionId,
                CoverType = dto.BookEditionDTO.CoverType,
                PhotoUrl = dto.BookEditionDTO.PhotoUrl,
                Isbn = dto.BookEditionDTO.Isbn,
                EditionDate = dto.BookEditionDTO.EditionDate,
                PagesCount = dto.BookEditionDTO.PagesCount,
            };

            var book = await bookRepo.GetAsync(e => e.Title.ToLower() == dto.Title.ToLower())
                        ?? throw new NotFoundException("Something went wrong", $"{dto.Title}");



            book.BookEditions.Add(bookEdition);

            if (await _unitOfWork.CommitAsync())
                return book.Id;

            return 0;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var bookRepo = _unitOfWork.GetRepository<Book>();

            var book = await bookRepo.GetAsync(e => e.Id == id);

            if (book == null)
                throw new NotFoundException("", $"{id}");

            await bookRepo.DeleteAsync(book);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> UpdateAsync(int id, BookDto expectedEntityValues)
        {

            var bookRepo = _unitOfWork.GetRepository<Book>();


            var validate = new BookValidator();
            var result = await validate.ValidateAsync(expectedEntityValues);

            if (!result.IsValid)
            {
                throw new BadRequestException("", result.ToDictionary());
            }

            var mapBook = _mapper.Map<Book>(expectedEntityValues);
            await bookRepo.UpdateAsync(mapBook);


            return await _unitOfWork.CommitAsync();

        }


    }
}
