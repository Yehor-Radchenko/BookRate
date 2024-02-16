using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services
{
    public class EditionService : IEditionService
    {
        public Task<bool> Create(EditionDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EditionViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<EditionViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(EditionDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
