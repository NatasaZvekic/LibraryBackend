using AutoMapper;
using Library.RepositoryContract.Entities;
using Library.RepositoryContract.Interfaces;
using Library.ServiceContract.DTOs.CreateDTO;
using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.DTOs.UpdateDTO;
using Library.ServiceContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public List<UserReadDTO> GetAllUsers()
        {
            return mapper.Map<List<UserReadDTO>>(userRepository.GetAllUsers());
        }

        public UserReadDTO GetUserByID(Guid userID)
        {
            return mapper.Map<UserReadDTO>(userRepository.GetUserByID(userID));
        }
        public Guid AddNewUser(UserCreateDTO user)
        {
            return userRepository.AddNewUser(mapper.Map<User>(user));
        }

        public void UpdateUser(UserUpdateDTO user, Guid userID)
        {
            userRepository.UpdateUser(mapper.Map<User>(user), userID);
        }
        public bool DeleteUser(Guid userID)
        {
            return userRepository.DeleteUser(userID);
        }

        public PrincipalReadDTO UserWithCredentialsExists(string email, string password)
        {
            return mapper.Map<PrincipalReadDTO>(userRepository.UserWithCredentialsExists(email, password));
        }
    }
}
