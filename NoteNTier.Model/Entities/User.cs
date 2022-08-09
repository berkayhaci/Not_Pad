using NoteNTier.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.Model.Entities
{
    public class User:BaseEntity
    {
        public User()
        {
            Notes = new HashSet<Note>();
            Passwords = new HashSet<Password>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public UserType UserType { get; set; }  //Kullanıcı admin mi standard mı
        public bool IsActive { get; set; }  // admin tarafından onaylı kullanıcı mı
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Password> Passwords { get; set; }
    }
}
