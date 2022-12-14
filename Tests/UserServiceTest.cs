using Application;
using Application.Interfaces;
using Moq;

namespace Tests
{
    public class UserServiceTest
    {
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


        [Fact]
        public void GetAllCoaches()
        {

        }
    }
}