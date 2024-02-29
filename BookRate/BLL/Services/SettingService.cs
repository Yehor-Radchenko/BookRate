using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;

namespace BookRate.BLL.Services
{
    public class SettingService : ISettingService
    {
        private readonly BookRateDbContext _context;
        private readonly IMapper _mapper;

        public SettingService(BookRateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> Create(SettingDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SettingViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SettingViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(SettingDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
