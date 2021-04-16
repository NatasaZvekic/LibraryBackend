using AutoMapper;
using Library.Repositories.Entities;
using Library.RepositoryContract.Entities;
using Library.RepositoryContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextDB context;
        private readonly IMapper mapper;

        public UserRepository(ContextDB context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<User> GetAllUsers()
        {
            return mapper.Map<List<User>>(context.Users.ToList());
        }

        public User GetUserByID(Guid userID)
        {
            var user = context.Users.FirstOrDefault(e => e.UserID == userID);
            return mapper.Map<User>(user);
        }

        public Guid AddNewUser(User user)
        {
            var newUser = mapper.Map<UserDB>(user);
            var guid = Guid.NewGuid();
            newUser.UserID = guid;

            context.Users.Add(newUser);
            context.SaveChanges();

            return guid;

        }

        public void UpdateUser(User user, Guid userID)
        {
            var oldUser = context.Users.FirstOrDefault(e => e.UserID == userID);

            if (oldUser == null)
            {
                throw new Exception("not found");
            }

            oldUser.UserName = user.UserName;
            oldUser.UserLastName = user.UserLastName;
            oldUser.UserAddress = user.UserAddress;
            oldUser.UserContact = user.UserContact;

            context.SaveChanges();
        }

        public bool DeleteUser(Guid userID)
        {
            var user = context.Users.FirstOrDefault(e => e.UserID == userID);
            if (user == null)
            {
                return false;
            }

            context.Users.Remove(user);
            context.SaveChanges();
            return true;
        }
    }
}
