using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services
{
    public class SerieService : ISerieService
    {
        public Task<bool> Create(SerieDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SerieViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SerieViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(SerieDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
