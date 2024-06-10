using AutoMapper;
using BookRate.BLL.HelperServices;
using BookRate.BLL.HelperServices.PasswordHash;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.User;
using BookRate.DAL.Context;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
using Mailjet.Client.Resources;
using Microsoft.EntityFrameworkCore;
using User = BookRate.DAL.Models.User;

namespace BookRate.BLL.Services
{
    public class UserService(IUnitOfWork unitOfWork, IMapper mapper, JwtService jwtService) : BaseService(unitOfWork, mapper),
        IService<ViewModels.User.User, ViewModels.User.User, BookRate.DAL.Models.User>
    {
        private readonly JwtService _jwtService = jwtService;
        public async Task<int> AddAsync(ViewModels.User.User dto)
        {
            var userRepo = unitOfWork.GetRepository<User>();
            var roleRepo = unitOfWork.GetRepository<Role>();


            var newUser = new User
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Username = dto.Username,
                Patronymic = dto.Patronymic,
                Password = PasswordHash.Hash(dto.Password),
                Interests = dto.Interests,
                Roles = new HashSet<Role>(),
            };

            await userRepo.AddAsync(newUser);
            var isSuccess = await _unitOfWork.CommitAsync();

            if (isSuccess)
            {
                var getUser = await userRepo.GetAsync(e => e.Email == dto.Email);
                var roles = await roleRepo.GetAllAsync();

                var userRoles = roles.Where(role => dto.RoleId.Contains(role.Id));

                foreach (var role in userRoles)
                {
                    getUser.Roles.Add(role);
                }

                await _unitOfWork.CommitAsync();
                return getUser.Id;
            }

            throw new Exception();
        }

        public async Task<bool> UpdateAsync(ViewModels.User.User expectedEntityValues)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> LoginAsync(LoginViewModel loginViewModel)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var getUser = await userRepo.GetAsync(e => e.Email.ToLower() == loginViewModel.Email.ToLower(),includeOptions:"Roles");

            return _jwtService.GenerateToken(getUser);

        }


    }
}
