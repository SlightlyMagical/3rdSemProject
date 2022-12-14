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

        public List<Coach> ReadAllCoaches()
        {
            return _context.CoachTable.ToList();
        }
    }
}