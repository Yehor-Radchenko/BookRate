using AutoMapper;
using BookRate.BLL.HelperServices;
using BookRate.BLL.Services;
using BookRate.DAL.DTO.User;
using BookRate.DAL.Models;
using BookRate.DAL.Repositories.EntityImplementations;
using BookRate.DAL.Repositories.IRepository;
using BookRate.DAL.UoW;
using BookRate.Test.Fixtures;
using FluentAssertions;
using FluentValidation;
using Moq;
using System.Linq.Expressions;


namespace BookRate.Test.System.Services
{
    public class UserServiceTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IValidator<UserDto>> _validatorMock;
        private readonly Mock<JwtService> _jwtServiceMock;
        private readonly UserService _userService;


        public UserServiceTest()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _validatorMock = new Mock<IValidator<UserDto>>();
            _jwtServiceMock = new Mock<JwtService>();

            _userService = new UserService(
                _unitOfWorkMock.Object, 
                _mapperMock.Object, 
                _validatorMock.Object, 
                _jwtServiceMock.Object
                );
        }

        [Fact]
        public async Task OnSuccess_LoginAsync_ShoudGivenToken()
        {
                       
            _jwtServiceMock.Setup(fn => fn.GenerateToken(UserData.UserForMock))
                                            .Returns(UserData.MockToken);

            var result = await _userService.LoginAsync(UserData.LoginInfo);

            result.Should().NotBeNull();
            result.Should().Be(UserData.MockToken);


            _unitOfWorkMock.Verify(repository => repository.UserRepository, Times.Once);
            _jwtServiceMock.Verify(fn => fn.GenerateToken(UserData.UserForMock), Times.Once);
        }


    }
}
