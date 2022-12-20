using Application.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        User AddNewUser(User user);
        List<Coach> ReadAllCoaches();
        User ReadUserByEmail(string email);
        void RebuildDB();
        bool UpdateWorkingHours(WorkingHoursDTO dto);
    }
}
