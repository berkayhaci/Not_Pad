using NoteNTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.DAL.Repositories
{
    public class UserRepository
    {
        NoteDbContext context;
        PasswordRepository passwordRepository;
        public UserRepository()
        {
            context = new NoteDbContext();
            passwordRepository = new PasswordRepository();
        }

        public bool Insert(User user)
        {
            context.Users.Add(user);
            return context.SaveChanges() > 0;
        }

        public User CheckLogin(string userName, string password)
        {
            User user = context.Users.Where(a => a.UserName == userName).SingleOrDefault();
            if(user != null)
            {
                Password userPassword = passwordRepository.GetActivePassword(user.ID);
                if(userPassword != null && userPassword.Text == password)
                {
                    return user;
                }
            }
            return null;
        }

        public void UserActivated(User user)
        {
            User activatedUser = context.Users.Find(user.ID);
            activatedUser.IsActive = true;
            context.SaveChanges();
        }

        public List<User> GetPassiveUsers()
        {
            return context.Users.Where(a => !a.IsActive).ToList();
        }

        public User GetUserById(int userID)
        {
            return context.Users.Find(userID);
        }
    }
}
