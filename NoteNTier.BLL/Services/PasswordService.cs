using NoteNTier.DAL.Repositories;
using NoteNTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.BLL.Services
{
    public class PasswordService
    {
        PasswordRepository passwordRepository;
        public PasswordService()
        {
            passwordRepository = new PasswordRepository();
        }

        bool CheckLastThreePasswords(Password password)
        {
            List<Password> lastThreePasswords = passwordRepository.GetLastThreePasswords(password.UserID);
            foreach (var item in lastThreePasswords)
            {
                if (item.Text == password.Text) throw new Exception("Bu şifre son üç şifreden biri");
            }
            return true;
        }

        public bool Insert(Password password)
        {
            if (CheckLastThreePasswords(password))
            {
                password.CreationDate = DateTime.Now;
                return passwordRepository.Insert(password);
            }
            return false;
        }

        public Password GetActivePassword(int userID)
        {
            if (userID <= 0) throw new Exception("Parametre geçersiz");
            return passwordRepository.GetActivePassword(userID);
        }


    }
}
