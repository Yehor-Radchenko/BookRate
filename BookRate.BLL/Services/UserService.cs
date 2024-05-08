using AutoMapper;
using BookRate.BLL.Services.IService;
using BookRate.BLL.ViewModels.User;
using BookRate.DAL.Context;
using BookRate.DAL.DTO;
using BookRate.DAL.DTO.User;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.IRepository;

namespace BookRate.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<bool> Add(CreateUserDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
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
