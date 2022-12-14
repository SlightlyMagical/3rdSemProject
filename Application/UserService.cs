using Application.Interfaces;
using Domain;

namespace Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            if (userRepository == null)
                throw new ArgumentException("Missing repository");
            _userRepository = userRepository; 
        }
        public List<Coach> GetAllCoaches()
        {
            return _userRepository.ReadAllCoaches();
        }
    }
}