using NoteNTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.DAL.Repositories
{
    public class PasswordRepository
    {
        NoteDbContext context;
        public PasswordRepository()
        {
            context = new NoteDbContext();
        }

        /// <summary>
        /// Son 3 password listesini doner
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<Password> GetLastThreePasswords(int userID)
        {
            return context.Passwords.Where(a => a.UserID == userID).OrderByDescending(a => a.CreationDate).Take(3).ToList();
        }

        public bool Insert(Password password)
        {
            context.Passwords.Add(password);
            return context.SaveChanges() > 0;
        }

        public Password GetActivePassword(int userID)
        {
            return context.Passwords.Where(a => a.UserID == userID).OrderByDescending(a => a.CreationDate).FirstOrDefault();
        }
    }
}
