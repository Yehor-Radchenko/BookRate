using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels;
using BookRate.DAL.DTO;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;

namespace BookRate.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly Repository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(Repository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<bool> Create(UserDTO model)
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

        public Task<bool> Update(UserDTO expectedEntityValues)
        {
            throw new NotImplementedException();
        }
    }
}
