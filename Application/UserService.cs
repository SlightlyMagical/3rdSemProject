using Application.DTOs;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentValidation;

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
            List<Coach> coaches = _userRepository.ReadAllCoaches();

            if (coaches == null || coaches.Count == 0)
                throw new ArgumentException("No coaches found");

            return coaches; 
        }

        public bool UpdateWorkingHours(WorkingHoursDTO dto)
        {
            return _userRepository.UpdateWorkingHours(dto);
        }
    }
}