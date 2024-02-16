using BookRate.DAL.DTO;

namespace BookRate.BLL.Services.IService
{
    public interface IBookService
    {
        public Task<bool> Create(BookDTO model);
    }
}
