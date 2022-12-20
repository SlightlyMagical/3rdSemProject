using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public static class PasswordHash
    {
        public static string HashPasswordBCrypt(this string plain)
        {
            return BCrypt.Net.BCrypt.HashPassword(plain);
        }

        public static bool VerifyHashedPasswordBCrypt(this string hashed, string plain)
        {
            return BCrypt.Net.BCrypt.Verify(plain, hashed);
        }
    }
}
