using BookRate.BLL.HelperServices;
using BookRate.BLL.ViewModels.User;
using BookRate.DAL.DTO.User;
using BookRate.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.Test.Fixtures
{
    public class UserData
    {

        public static readonly int NegativeId = -1;

        public static readonly string MockToken = "expectedToken";

        public static readonly User UserForMock = new User
        {
            Id = 1,
            Email = "Test",
            Username = "test",
            LastName = "Test",
            FirstName = "Test",
            IsGetBan = false,
        };

        public static readonly LoginDto LoginInfo = new LoginDto
        {
            Email = "test@gmail.com",
            Password = "12345"
        };

        public static readonly UserDto MockUserDto = new UserDto
        {
            Email = "test@gmail.com",
            Password = "password",
            ConfirmPassword = "password",
            Username = "12435",
            LastName = "Test",
            FirstName = "Test1",
            Patronymic = "Test2",
            Interests = "Read books",
        };

        public static readonly InfoViewModel ProfileInfo = new InfoViewModel
        {
            Id = 1,
            Email = "Test",
            Username = "Test",
            LastName = "Test",
            FirstName = "Test",
            Patronymic = "Test",
            Interests = "Read books",
            CountCommentaries = 1,
            CountReviews = 1,
        };


        public static List<UserViewModel> GetUsers()
        {
            return new List<UserViewModel>
            {

                new UserViewModel
                {
                    Id = 1,
                    FirstName = "Test",
                    LastName = "Test",
                    Password = "Test",
                    Patronymic = "Test",
                    Email = "Test@gmail.com",
                    Interests = "Test",
                    Username = "Test",
                },


                new UserViewModel
                {
                    Id = 2,
                    FirstName = "Test",
                    LastName = "Test",
                    Password = "Test",
                    Patronymic = "Test",
                    Email = "Test@gmail.com",
                    Interests = "Test",
                    Username = "Test",
                },


                new UserViewModel
                {
                    Id = 3,
                    FirstName = "Test",
                    LastName = "Test",
                    Password = "Test",
                    Patronymic = "Test",
                    Email = "Test@gmail.com",
                    Interests = "Test",
                    Username = "Test",
                },


                new UserViewModel
                {
                    Id = 4,
                    FirstName = "Test",
                    LastName = "Test",
                    Password = "Test",
                    Patronymic = "Test",
                    Email = "Test@gmail.com",
                    Interests = "Test",
                    Username = "Test",
                },


                new UserViewModel
                {
                    Id = 5,
                    FirstName = "Test",
                    LastName = "Test",
                    Password = "Test",
                    Patronymic = "Test",
                    Email = "Test@gmail.com",
                    Interests = "Test",
                    Username = "Test",
                },
            };
        }

        public static bool AddAsync()
        {
            return true;
        }


    }
}
