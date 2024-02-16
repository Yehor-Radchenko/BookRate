using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services
{
    public class RevardService : IRevardService
    {
        public Task<bool> Create(RevardDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RevardViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<RevardViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(RevardDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
