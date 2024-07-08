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

        public readonly static int NegativeId = -1;

        public  static string MockToken => "expectedToken";

        public  static User UserForMock => new User
        {
            Id = 1,
            Email = "Test",
            Username = "test",
            LastName = "Test",
            FirstName = "Test",
            IsGetBan = false,
        };

        public readonly static LoginDto LoginInfo = new LoginDto
        {
            Email = "test@gmail.com",
            Password = "12345"
        };

        public readonly static UserDto MockUserDto = new UserDto
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

        public readonly static InfoViewModel ProfileInfo = new InfoViewModel
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
            return
            [
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
                }

            ];
        }

        public static bool AddAsync()
        {
            return true;
        }


    }
}
