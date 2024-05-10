using BookRate.DAL.Context;

namespace ServicesTest
{
    public class BookServiceTest : IDisposable
    {
        private readonly BookRateDbContext _context;
        private readonly BookService _service;
       
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}