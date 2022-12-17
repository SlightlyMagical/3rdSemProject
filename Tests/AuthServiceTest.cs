using Application;
using Application.DTOs;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class AuthServiceTest
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private IUserRepository _repository;
        private IAuthService _authService;

        public AuthServiceTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _repository = _userRepositoryMock.Object;

            _authService = new AuthService(_repository, new PostUserValidator());

        }
        //Test 3.1 + 3.2
        [Theory]
        [InlineData("Peter", "email@email.com", "MyPassword123", "Client")]
        [InlineData("Peter", "email@email.com", "MyPassword123", "Coach")]
        public void CreateNewUserValid(string name, string email, string password, string usertype)
        {
            //Arrange
            PostUserDTO dto = new PostUserDTO() { Name = name, Email = email, Password = password, Usertype = usertype };
            User validUser = new User();

            switch (usertype)
            {
                case "Client":
                    validUser = new Client() { Name = name, Email = email, Password = password };
                    break;

                case "Coach":
                    validUser = new Coach() { Name = name, Email = email, Password = password };
                    break;
            }

            _userRepositoryMock.Setup(x => x.AddNewUser(It.IsAny<User>())).Returns(validUser);

            //Act
            User result = _authService.RegisterUser(dto);

            //Assert
            Assert.Equal(validUser, result);
            _userRepositoryMock.Verify(x => x.AddNewUser(It.IsAny<User>()), Times.Once);
        }

        //Test 3.3
        [Theory]
        [InlineData("", "email@email.com", "MyPassword123", "Client")]
        [InlineData(null, "email@email.com", "MyPassword123", "Client")]
        [InlineData("Peter", "", "MyPassword123", "Client")]
        [InlineData("Peter", null, "MyPassword123", "Client")]
        [InlineData("Peter", "email@email.com", "", "Client")]
        [InlineData("Peter", "email@email.com", null, "Client")]
        [InlineData("Peter", "email@email.com", "MyPassword123", "")]
        [InlineData("Peter", "email@email.com", "MyPassword123", null)]
        [InlineData("Peter", "email@email.com", "MyPassword123", "Admin")]
        public void CreateNewUserInvalid(string name, string email, string password, string usertype)
        {
            //Arrange
            PostUserDTO dto = new PostUserDTO() { Name = name, Email = email, Password = password, Usertype = usertype };
            User invalidUser = new User() { Name = name, Email = email, Password = password };

            _userRepositoryMock.Setup(x => x.AddNewUser(invalidUser)).Returns(invalidUser);


            //Act + Assert
            Assert.Throws<ValidationException>(() => _authService.RegisterUser(dto));
            _userRepositoryMock.Verify(x => x.AddNewUser(It.IsAny<User>()), Times.Never);
        }
    }
}
