using NoteNTier.DAL.Repositories;
using NoteNTier.Model.Entities;
using NoteNTier.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.BLL.Services
{
    public class UserService
    {
        UserRepository userRepository;
        public UserService()
        {
            userRepository = new UserRepository();
        }

        public bool Insert(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName)) throw new Exception("FirstName ve/veya LastName bilgilerini giriniz");

            Password firstPassword = user.Passwords.FirstOrDefault();
            if (firstPassword == null) throw new Exception("Password girin");

            user.CreationDate = DateTime.Now;
            user.Passwords.FirstOrDefault().CreationDate = DateTime.Now;
            user.IsActive = false;
            user.UserType = UserType.Standard;
            return userRepository.Insert(user);
        }

        public User CheckLogIn(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password)) throw new Exception("UserName ve/veya Password bilgilerini giriniz");
            return userRepository.CheckLogin(userName, password);
        }

        public void UserActivated(User user)
        {
            CheckUserId(user);
            userRepository.UserActivated(user);
        }

        void CheckUserId (User user)
        {
            if (user.ID <= 0) throw new Exception("User id boş olamaz");
        }

        public void UserActivated(int id)
        {
            User user = userRepository.GetUserById(id);
            CheckUserId(user);
            userRepository.UserActivated(user);
        }

        public List<User> GetPassiveUsers()
        {
            return userRepository.GetPassiveUsers();
        }

    }
}
