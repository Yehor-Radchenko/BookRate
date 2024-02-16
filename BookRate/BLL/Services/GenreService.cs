using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services
{
    public class GenreService : IGenreService
    {
        public Task<bool> Create(GenreDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GenreViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<GenreViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(GenreDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
