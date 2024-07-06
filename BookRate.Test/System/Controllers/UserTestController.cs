

using BookRate.BLL.HelperServices;
using BookRate.BLL.Services;
using BookRate.BLL.ViewModels.User;
using BookRate.Controllers;
using BookRate.DAL.DTO.User;
using BookRate.Test.Fixtures;
using Castle.Core.Configuration;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Runtime.CompilerServices;

namespace BookRate.Test.System.Controllers
{
    public class UserTestController
    {
        private readonly Mock<UserService> _userServiceMock;
        private readonly Mock<IHttpContextAccessor> _contextAccessorMock;
        private readonly UserController _userControllerMock;
        private readonly Mock<Microsoft.Extensions.Configuration.IConfiguration> _configurationMock;

        public UserTestController()
        {
            _userServiceMock = new Mock<UserService>();
            _contextAccessorMock = new Mock<IHttpContextAccessor>();
            _userControllerMock = new UserController(_userServiceMock.Object, _contextAccessorMock.Object);
        }

        [Fact]
        public async Task OnSuccess_GetUsersAsync_WhereShoudListsOfUsers()
        {
            _userServiceMock.Setup(service => service.GetUsersAsync())
                                .ReturnsAsync(UserData.GetUsers());

            var result = (OkObjectResult)await _userControllerMock.GetUsersAsync();

            var users = (List<UserViewModel>)result.Value;

            Assert.Equal(5, users.Count);
        }

        [Fact]
        public async Task OnSuccess_GetUserAsync_WhereShoudUsers()
        {

            _userServiceMock.Setup(service => service.GetInfoAboutProfileAsync(It.IsAny<int>()))
                               .ReturnsAsync(UserData.ProfileInfo);


            var result = (OkObjectResult)await _userControllerMock.ProfileInfoAsync(1);

            result.Should().NotBeNull();
            result.Value.Should().BeOfType<InfoViewModel>();

            _userServiceMock.Verify(service => service.GetInfoAboutProfileAsync(It.Is<int>(e => e == UserData.ProfileInfo.Id)), Times.Once);
        }

        [Fact]
        public async Task OnSuccess_AddAsync_ShoudCreateUser()
        {
            _userServiceMock.Setup(service => service.AddAsync(It.IsAny<UserDto>()))
                            .ReturnsAsync(UserData.AddAsync());

            var result = (OkObjectResult)await _userControllerMock.RegisterUserAsync(UserData.MockUserDto);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);

            _userServiceMock.Verify(service => service.AddAsync(It.Is<UserDto>(e => e == UserData.MockUserDto)), Times.Once);

        }

        [Fact]
        public async Task OnSuccess_GetBadRequest_WhenGiveNegativeID()
        {
            var result = await _userControllerMock.ProfileInfoAsync(UserData.NegativeId);

            result.Should().BeOfType<BadRequestResult>();

            _userServiceMock.Verify(service => service.GetInfoAboutProfileAsync(UserData.NegativeId), Times.Never);
        }

  
    }
}
