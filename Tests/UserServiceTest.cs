using Application;
using Application.Interfaces;
using Domain;
using Moq;

namespace Tests
{
    public class UserServiceTest
    {
        //Test 1.1
        [Fact]
        public void CreateUserServiceValidRepo() 
        {
            //Arrange
            IUserService userService = null;

            Mock<IUserRepository> mockRepository = new Mock<IUserRepository>();
            IUserRepository repository = mockRepository.Object;

            //Act
            userService = new UserService(repository);

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

            Mock<IUserRepository> mockRepository = new Mock<IUserRepository>();
            IUserRepository repository = mockRepository.Object;
            mockRepository.Setup(x => x.ReadAllCoaches()).Returns(expected);

            IUserService userService = new UserService(repository);

            //Act
            var result = userService.GetAllCoaches();

            //Assert
            Assert.Equal(expected, result);
            mockRepository.Verify(x => x.ReadAllCoaches(), Times.Once);
        }

        //Test 2.2
        [Fact]
        public void GetAllCoachesInvalid()
        {
            //Arrange
            List<Coach> expected = new List<Coach>() {};

            Mock<IUserRepository> mockRepository = new Mock<IUserRepository>();
            IUserRepository repository = mockRepository.Object;
            mockRepository.Setup(x => x.ReadAllCoaches()).Returns(expected);

            IUserService userService = new UserService(repository);

            //Act + Assert
            var ex = Assert.Throws<ArgumentException>(() => userService.GetAllCoaches());

            Assert.Equal("No coaches found", ex.Message);
            mockRepository.Verify(x => x.ReadAllCoaches(), Times.Once);
        }
    }
}