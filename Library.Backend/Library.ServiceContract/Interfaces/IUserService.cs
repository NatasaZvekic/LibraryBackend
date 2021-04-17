using Library.ServiceContract.DTOs.CreateDTO;
using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.DTOs.UpdateDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ServiceContract.Interfaces
{
    public interface IUserService
    {
        List<UserReadDTO> GetAllUsers();
        UserReadDTO GetUserByID(Guid userID);
        Guid AddNewUser(UserCreateDTO user);
        void UpdateUser(UserUpdateDTO user, Guid userID);
        bool DeleteUser(Guid userID);
        String UserWithCredentialsExists(string email, string password);
    }
}
