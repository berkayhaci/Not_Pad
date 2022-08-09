using NoteNTier.Model.Entities;
using NoteNTier.Model.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.DAL.Strategy
{
    class NoteStrategy:CreateDatabaseIfNotExists<NoteDbContext>
    {
        protected override void Seed(NoteDbContext context) // database oluşurken içinde olmasını istediğim dataları seed metodu ile içine atıyorum
        {
            User user = new User
            {
                FirstName = "Admin",
                LastName = "Admin",
                CreationDate = DateTime.Now,
                IsActive = true,
                UserName = "admin",
                UserType = UserType.Admin
            };

            user.Passwords.Add(new Password()
            {
                CreationDate = DateTime.Now,
                Text = "qwerty"
            });

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
