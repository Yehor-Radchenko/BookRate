using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;

namespace BookRate.BLL.Services
{
    public class RateService : IRateService
    {
        public Task<bool> Create(RateDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RateViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<RateViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(RateDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
