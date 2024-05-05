using BookRate.BLL.Services;
using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;
using BookRate.DAL.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ServicesTest
{
    public class BookServiceTest : IDisposable
    {
        private readonly BookRateDbContext _context;
        private readonly BookService _service;

        public BookServiceTest()
        {
            var options = new DbContextOptionsBuilder<BookRateDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new BookRateDbContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.Migrate();

            _service = new BookService(new BookRepository(_context));
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}