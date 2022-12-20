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
                ReadUserByEmail(user.Email);
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

        public User ReadUserByEmail(string email)
        {
            return _context.UserTable.FirstOrDefault(u => u.Email == email) ?? throw new KeyNotFoundException("There was no user with email " + email);
        }

        public void RebuildDB()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public bool UpdateWorkingHours(WorkingHoursDTO dto)
        {
            Coach coach = _context.CoachTable.FirstOrDefault(x => x.Email == dto.Email) ?? throw new KeyNotFoundException("There was no user with email " + dto.Email);
            
            if(coach != null)
            {
                coach.StartTime = dto.StartTime;
                coach.EndTime = dto.EndTime;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}