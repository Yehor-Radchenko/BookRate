using AutoMapper;
using BookRate.BLL.Exceptions;
using BookRate.BLL.HelperServices;
using BookRate.BLL.HelperServices.PasswordHash;
using BookRate.BLL.Services.ServiceAbstraction;
using BookRate.BLL.ViewModels.User;
using BookRate.DAL.DTO.Restrict;
using BookRate.DAL.DTO.User;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories;
using BookRate.DAL.Repositories.IRepository;
using BookRate.DAL.UoW;
using BookRate.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using User = BookRate.DAL.Models.User;

namespace BookRate.BLL.Services
{
    public  class UserService : BaseService<User,UserDto>
    {
        public UserService()
        { }

        private readonly JwtService _jwtService;
        
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UserDto> validator, JwtService jwtService) 
            : base(unitOfWork, mapper, validator)
        {
            _jwtService = jwtService;
        }
        public virtual async Task<InfoViewModel> GetInfoAboutProfileAsync(int id)
        {

            var userRepo = _unitOfWork.GetRepository<User>();
            var getUser = await userRepo
                .GetAsync(e => e.Id == id,
                includeOptions: "Rates,ReviewLikes,Reviews,Commentaries,CommentaryLikes");

            if (getUser == null)
                throw new NotFoundException($"User isn`t find", $"{id}");


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

        public virtual async Task<List<UserViewModel>> GetUsersAsync()
        {
            var userRepo =  _unitOfWork.GetRepository<User>();

            var users = await userRepo.GetAllAsync(includeOptions: "Commentaries,Rates");

            var map = _mapper.Map<List<UserViewModel>>(users);
           
            return map;
        }

        public virtual async Task<bool> AddAsync(UserDto dto)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var roleRepo = _unitOfWork.GetRepository<Role>();

            var validator = new UserValidator(_unitOfWork);
            var result = await validator.ValidateAsync(dto);

            if (!result.IsValid)
                throw new BadRequestException("Something went wrong", result.ToDictionary());

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


            var getUser = await userRepo.GetAsync(e => e.Email == dto.Email);
            var roles = await roleRepo.GetAllAsync();

            var userRoles = roles.Where(role => dto.RolesId.Contains(role.Id));

            foreach (var role in userRoles)
            {
                getUser.Roles.Add(role);
            }

            return await _unitOfWork.CommitAsync() ? true : throw new Exception();

        }

        public virtual async Task<bool> UpdateAsync(string email, UpdateUserDto expectedEntityValues)
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

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var user = await userRepo.GetAsync(e => e.Id == id);

            await userRepo.DeleteAsync(user);
            return await _unitOfWork.CommitAsync();
        }

        public virtual async Task<string> LoginAsync(LoginDto loginDto)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var getUser = await userRepo.GetAsync(e => e.Email.ToLower() == loginDto.Email.ToLower(), 
                                                                                includeOptions: "Roles");

            if (getUser == null)
                throw new ConflictException($"User isn`t find: {loginDto.Email}");

            return _jwtService.GenerateToken(getUser);
        }

        public virtual async Task<bool> BanUserAsync(RestrictDto restrictDto)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var restrictRepo = _unitOfWork.GetRepository<Restrict>();

            var getUser = await userRepo.GetAsync(e => e.Id == restrictDto.UserId);
            var getRestrictToThisUser = await restrictRepo.GetAsync(e => e.UserId == restrictDto.UserId);

            if (getUser == null)
                throw new ConflictException($"User isn`t find: {restrictDto.UserId}");

            if (getUser.IsGetBan)
                throw new ConflictException($"User: {getUser.Username} already have ban: {getRestrictToThisUser!.BanRemovalDate}");

            getUser.IsGetBan = true;

            var restrict = new Restrict
            {
                UserId = getUser.Id,
                Description = restrictDto.Description,
                BanRemovalDate = restrictDto.BanRemovaleDate,
            };

        
            if (restrict.BanRemovalDate == DateTime.Now)
                throw new BadRequestException($"Ban time must be more then by the time now at least 1 min");


            await restrictRepo.AddAsync(restrict);
            return await _unitOfWork.CommitAsync();
        }

        public virtual async Task<bool> UnbanUserAsync(int id)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var restrictRepo = _unitOfWork.GetRepository<Restrict>();

            var user = await userRepo.GetAsync(e => e.Id == id);

            if (user == null)
                throw new NotFoundException($"User isn`t find: {id}");

            if (!user.IsGetBan)
                throw new ConflictException($"User: {user.Username},don`t have any resctrict");

            if (user != null)
            {
                var restrict = await restrictRepo.GetAsync(e => e.UserId == user.Id);
                await restrictRepo.DeleteAsync(restrict);
                user.IsGetBan = false;

                return await _unitOfWork.CommitAsync();
            }

            throw new BadRequestException("Something went wrong,try again");
        }


    }
}
