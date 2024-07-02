using AutoMapper;
using BookRate.BLL.HelperServices;
using BookRate.BLL.HelperServices.PasswordHash;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.User;
using BookRate.DAL.Context;
using BookRate.DAL.DTO.User;
using BookRate.DAL.Models;
using BookRate.DAL.UoW;
using FluentValidation;
using Mailjet.Client.Resources;
using Microsoft.EntityFrameworkCore;
using User = BookRate.DAL.Models.User;

namespace BookRate.BLL.Services
{
    public class UserService : BaseService<User, UserDto>
    {
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UserDto> validator, JwtService jwtService)
            : base(unitOfWork, mapper, validator)
        {
            _jwtService = jwtService;
        }

        private readonly JwtService _jwtService;

        public async Task<UserViewModel> GetInfoAboutProfileAsync(int id)
        {
            var userRepo = _unitOfWork.GetRepository<User>();

            var getUser = await userRepo
                .GetAsync(e => e.Id == id,
                includeOptions: "Rates,ReviewLikes,Reviews,Commentaries,CommentaryLikes");
            
            var info = new UserViewModel
            {
                Id = getUser!.Id,
                Email = getUser.Email,
                Username = getUser.Username,
                FirstName = getUser.FirstName,
                LastName = getUser.LastName,
                Interests = getUser.Interests,
                Patronymic = getUser.Patronymic,
                CountCommentaries = getUser.Commentaries.Count(),
                CountReviews = getUser.Reviews.Count(),
            };
            
            return info;
        }

        public async Task<int> AddAsync(UserDto dto)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var roleRepo = _unitOfWork.GetRepository<Role>();

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

                var userRoles = roles.Where(role => dto.RolesId.Contains(role.Id));

                foreach (var role in userRoles)
                {
                    getUser.Roles.Add(role);
                }

                await _unitOfWork.CommitAsync();
                return getUser.Id;
            }

            throw new Exception();
        }

        public async Task<bool> UpdateAsync(string email, UserDto expectedEntityValues)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var roleRepo = _unitOfWork.GetRepository<Role>();
            var getUser = await userRepo.GetAsync(e => e.Email.ToLower() == email.ToLower(), includeOptions: "Roles");

            if (getUser != null)
            {
                getUser.LastName = expectedEntityValues.LastName;
                getUser.FirstName = expectedEntityValues.FirstName;
                getUser.Patronymic = expectedEntityValues.Patronymic;
                getUser.Interests = expectedEntityValues.Interests;

                var roleList = await roleRepo.GetAllAsync();

                roleList = roleList.Where(role => expectedEntityValues.RolesId.Contains(role.Id));

                foreach (var role in roleList)
                {
                    getUser.Roles.Add(role);
                }

                await userRepo.UpdateAsync(getUser);
                await _unitOfWork.CommitAsync();

            }

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> LoginAsync(LoginDto loginViewModel)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var getUser = await userRepo.GetAsync(e => e.Email.ToLower() == loginViewModel.Email.ToLower(), includeOptions: "Roles");

            return _jwtService.GenerateToken(getUser);

        }
    }
}
