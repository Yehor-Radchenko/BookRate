using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;

namespace BookRate.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly BookRateDbContext _context;
        private readonly IMapper _mapper;

        public UserService(BookRateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> Create(UpdateUserDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel?> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UpdateUserDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
