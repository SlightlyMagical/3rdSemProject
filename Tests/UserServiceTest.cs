using Application;
using Application.Interfaces;
using Application.Validators;
using Domain;
using Moq;
using AutoMapper;
using Application.DTOs;

namespace Tests
{
    public class UserServiceTest
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private IUserRepository _repository;
        private IUserService _userService;

        public UserServiceTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _repository = _userRepositoryMock.Object;

            _userService = new UserService(_repository);
            
        }

        //Test 1.1
        [Fact]
        public void CreateUserServiceValidRepo() 
        {
            //Arrange
            IUserService userService = null;

            //Act
            userService = new UserService(_repository);

            //Assert
            Assert.True(userService is UserService);
        }

        //Test 1.2
        [Fact]
        public void CreateUserServiceInvalidRepo()
        {
            //Arrange
            IUserService userService = null;

            //Act + Assert
            var ex = Assert.Throws<ArgumentException>(() => userService = new UserService(null));

            Assert.Equal("Missing repository", ex.Message);
            Assert.Null(userService);
        }

        //Test 2.1
        [Fact]
        public void GetAllCoachesValid()
        {
            //Arrange
            List<Coach> expected = new List<Coach>() {new Coach()};

            _userRepositoryMock.Setup(x => x.ReadAllCoaches()).Returns(expected);

            //Act
            var result = _userService.GetAllCoaches();

            //Assert
            Assert.Equal(expected, result);
            _userRepositoryMock.Verify(x => x.ReadAllCoaches(), Times.Once);
        }

        //Test 2.2
        [Fact]
        public void GetAllCoachesInvalid()
        {
            //Arrange
            List<Coach> emptyCoachList = new List<Coach>() {};

            _userRepositoryMock.Setup(x => x.ReadAllCoaches()).Returns(emptyCoachList);

            //Act + Assert
            var ex = Assert.Throws<ArgumentException>(() => _userService.GetAllCoaches());

            Assert.Equal("No coaches found", ex.Message);
            _userRepositoryMock.Verify(x => x.ReadAllCoaches(), Times.Once);
        }

    }
}