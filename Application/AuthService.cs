using Application.DTOs;
using Application.Helpers;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly PostUserValidator _postUserValidator;

        public AuthService(IUserRepository userRepository, PostUserValidator postUserValidator)
        {
            if (userRepository == null)
                throw new ArgumentException("Missing repository");
            if (postUserValidator == null)
                throw new ArgumentException("Missing validator");

            _userRepository = userRepository;
            _postUserValidator = postUserValidator;
        }

        public User RegisterUser(PostUserDTO dto)
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
                        Password = PasswordHash.HashPasswordBCrypt(dto.Password) 
                    };
                    break;

                case "Coach":
                    userToCreate = new Coach()
                    {
                        Name = dto.Name,
                        Email = dto.Email,
                        Password = PasswordHash.HashPasswordBCrypt(dto.Password)
                    };
                    break;
            }

            return _userRepository.AddNewUser(userToCreate);
        }
    }
}
