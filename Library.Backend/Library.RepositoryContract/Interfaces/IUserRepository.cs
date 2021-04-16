using Library.RepositoryContract.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.RepositoryContract.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserByID(Guid userID);
        Guid AddNewUser(User user);
        void UpdateUser(User user, Guid userID);
        bool DeleteUser(Guid userID);

    }
}
