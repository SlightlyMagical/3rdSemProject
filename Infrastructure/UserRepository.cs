using Application.DTOs;
using Application.Interfaces;
using Domain;

namespace Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext _context;

        public UserRepository(DatabaseContext databaseContext)
        {
            _context = databaseContext;
        }

        public User AddNewUser(User user)
        {
            try
            {
                _context.UserTable.FirstOrDefault(u => u.Email == user.Email);
                throw new Exception("This email is already in use");
            }
            catch (KeyNotFoundException)
            {
                _context.UserTable.Add(user);
                _context.SaveChanges();
                return user;
            }
        }

        public List<Coach> ReadAllCoaches()
        {
            return _context.CoachTable.ToList();
        }
    }
}