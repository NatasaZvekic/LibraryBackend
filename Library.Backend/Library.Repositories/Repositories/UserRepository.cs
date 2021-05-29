using AutoMapper;
using Library.Repositories.Entities;
using Library.RepositoryContract.Entities;
using Library.RepositoryContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Library.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextDB context;
        private readonly IMapper mapper;
        private readonly static int iterations = 1000;

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
                newUser.Role = "user";
                var pass = HashPassword(user.Password);
                newUser.Salt = pass.Item2;
                newUser.Password = pass.Item1;

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
            oldUser.Email= user.Email;
            oldUser.Role = user.Role;
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

       
        public Principal UserWithCredentialsExists(string email, string password)
        {
            var user = context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                var employee = context.Employee.FirstOrDefault(e => e.Email == email);
                if (employee == null)
                {
                    throw new Exception("not found");
                }
                PrincipalDB principal1 = new PrincipalDB
                {
                    Email = employee.Email,
                    Password = employee.Password,
                    Salt = employee.Salt,
                    Role = employee.Role,
                    UserID = employee.EmployeeID,
                    UserName = employee.EmployeeName,
                    UserLastName = employee.EmployeeLastName

                };
                if (!VerifyPassword(password, principal1.Password, principal1.Salt))
                {
                    throw new Exception("not found");
                }
                return mapper.Map<Principal>(principal1);
               
            }
            

            PrincipalDB principal = new PrincipalDB
            {
                Email = user.Email,
                Password = user.Password,
                Salt = user.Salt,
                UserID = user.UserID,
                UserName = user.UserName,
                UserLastName = user.UserLastName,
                Role = user.Role,
            };
            if (!VerifyPassword(password, principal.Password, principal.Salt))
            {
                throw new Exception("not found");
            }
            return mapper.Map<Principal>(principal);



        }
        private Tuple<string, string> HashPassword(string password)
        {
            var sBytes = new byte[password.Length];
            new RNGCryptoServiceProvider().GetNonZeroBytes(sBytes);
            var salt = Convert.ToBase64String(sBytes);

            var derivedBytes = new Rfc2898DeriveBytes(password, sBytes, iterations);

            return new Tuple<string, string>
            (
                Convert.ToBase64String(derivedBytes.GetBytes(256)),
                salt
            );
        }

        public bool VerifyPassword(string password, string savedHash, string savedSalt)
        {
            var saltBytes = Convert.FromBase64String(savedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, iterations);
            if (Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == savedHash)
            {
                return true;
            }
            return false;
        }
    }
}
