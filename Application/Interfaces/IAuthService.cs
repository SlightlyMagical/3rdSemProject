using Application.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        string Login(LoginDTO dto);
        string RegisterUser(PostUserDTO dto);
        string GenerateToken(User user);
    }
}
