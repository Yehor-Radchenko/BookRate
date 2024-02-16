using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services
{
    public class NarrativeService : INarrativeService
    {
        public Task<bool> Create(NarrativeDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NarrativeViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<NarrativeViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(NarrativeDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
