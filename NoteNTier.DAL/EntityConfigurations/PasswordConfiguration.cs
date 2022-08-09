using NoteNTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.DAL.EntityConfigurations
{
    class PasswordConfiguration: EntityTypeConfiguration<Password>
    {
        public PasswordConfiguration()
        {
            Property(a => a.Text).IsRequired().HasMaxLength(20);

            //1 to many relation
            //HasRequired(a => a.User).WithMany(a => a.Passwords).HasForeignKey(a => a.UserID);
        }
    }
}
