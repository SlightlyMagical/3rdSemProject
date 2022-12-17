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
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper) 
        {
            if (userRepository == null)
                throw new ArgumentException("Missing repository");

            _userRepository = userRepository; 
            _mapper = mapper;
        }


        public List<Coach> GetAllCoaches()
        {
            List<Coach> coaches = _userRepository.ReadAllCoaches();

            if (coaches == null || coaches.Count == 0)
                throw new ArgumentException("No coaches found");

            return coaches; 
        }
    }
}