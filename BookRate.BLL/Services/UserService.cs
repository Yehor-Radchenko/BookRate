using AutoMapper;
using BookRate.BLL.Exceptions;
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

        public async Task<InfoViewModel> GetInfoAboutProfileAsync(int id)
        {
            var userRepo = _unitOfWork.GetRepository<User>();

            var getUser = await userRepo
                .GetAsync(e => e.Id == id,
                includeOptions: "Rates,ReviewLikes,Reviews,Commentaries,CommentaryLikes");

            var info = new InfoViewModel
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

            if (!isSuccess)
            {
                throw new Exception();
            }

            var getUser = await userRepo.GetAsync(e => e.Email == dto.Email);
            var roles = await roleRepo.GetAllAsync();

            var userRoles = roles.Where(role => dto.RolesId.Contains(role.Id));

            foreach (var role in userRoles)
            {
                getUser.Roles.Add(role);
            }

            return await _unitOfWork.CommitAsync() ? getUser.Id : throw new Exception();
            
        }

        public async Task<bool> UpdateAsync(string email, UpdateUserDto expectedEntityValues)
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

                roleList = roleList.Where(role => expectedEntityValues.Roles.Contains(role.Id));

                foreach (var role in roleList)
                {
                    getUser.Roles.Add(role);
                }

                await userRepo.UpdateAsync(getUser);
                await _unitOfWork.CommitAsync();
            }

            return true;
        }
        
        public async Task<bool> DeleteAsync(int id)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var user = await userRepo.GetAsync(e => e.Id == id);

            await userRepo.DeleteAsync(user);
            return await _unitOfWork.CommitAsync();
        }
        
        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var getUser = await userRepo.GetAsync(e => e.Email.ToLower() == loginDto.Email.ToLower(), includeOptions: "Roles");

            return _jwtService.GenerateToken(getUser);
        }
        
        public async Task<bool> BanUserAsync(int id)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var restrictRepo = _unitOfWork.GetRepository<Restrict>();

            var getUser = await userRepo.GetAsync(e => e.Id == id);

            if (getUser == null)
            {
                throw new NotFoundException("Something went wrong", $"{getUser.Email}");
            }
            getUser.IsGetBan = true;

            var restrict = new Restrict
            {
                UserId = getUser.Id,
                Description = "",
                BanRemovalDate = DateTime.Now.AddDays(7)
            };

            await restrictRepo.AddAsync(restrict);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> UnbanUserAsync(int id)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var restrictRepo = _unitOfWork.GetRepository<Restrict>();

            var user = await userRepo.GetAsync(e => e.Id == id);

            if (user != null)
            {
                var restrict = await restrictRepo.GetAsync(e => e.UserId == user.Id);
                await restrictRepo.DeleteAsync(restrict);
                user.IsGetBan = false;

                return await _unitOfWork.CommitAsync();
            }

            throw new Exception("Something went wrong,try again");
        }


    }
}
