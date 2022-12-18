using Application.DTOs;
using Application.Helpers;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentValidation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly PostUserValidator _postUserValidator;
        private readonly AppSettings _appSettings;

        public AuthService(IUserRepository userRepository, 
            PostUserValidator postUserValidator)
        {
            if (userRepository == null)
                throw new ArgumentException("Missing repository");
            if (postUserValidator == null)
                throw new ArgumentException("Missing validator");

            _userRepository = userRepository;
            _postUserValidator = postUserValidator;
            _appSettings = new AppSettings();
        }

        public string GenerateToken(User user)
        {
            var key = Encoding.UTF8.GetBytes(AppSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("email", user.Email), new Claim("usertype", user.Usertype) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        public string Login(LoginDTO dto)
        {
            User user = _userRepository.ReadUserByEmail(dto.Email);
            var verfication = user.Password.VerifyHashedPasswordBCrypt(dto.Password);
            if (verfication)
                return GenerateToken(user);
            throw new ArgumentException("Invalid login");
        }

        public string RegisterUser(PostUserDTO dto)
        {
            var validation = _postUserValidator.Validate(dto);

            if (!validation.IsValid)
                throw new ValidationException(validation.ToString());

            User userToCreate = null;

            switch (dto.Usertype)
            {
                case "Client":
                    userToCreate = new Client()
                    {
                        Name = dto.Name,
                        Email = dto.Email,
                        Password = PasswordHash.HashPasswordBCrypt(dto.Password),
                        Usertype = dto.Usertype
                    };
                    break;

                case "Coach":
                    userToCreate = new Coach()
                    {
                        Name = dto.Name,
                        Email = dto.Email,
                        Password = PasswordHash.HashPasswordBCrypt(dto.Password),
                        Usertype = dto.Usertype
                    };
                    break;
            }
            _userRepository.AddNewUser(userToCreate);
            return GenerateToken(userToCreate);
        }
    }
}
