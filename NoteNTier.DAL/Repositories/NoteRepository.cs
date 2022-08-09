using NoteNTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.DAL.Repositories
{
    public class NoteRepository  //Note ile ilgili işleri barındıracak / işlerden sorumlu class
    {
        NoteDbContext context;
        public NoteRepository()
        {
            context = new NoteDbContext();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<Note> GetByUserId(int userID)
        {
            return context.Notes.Where(a => a.UserID == userID && a.IsActive).ToList();
        }

        public Note GetByNoteId(int noteID)
        {
            return context.Notes.Find(noteID);
        }

        public bool Insert(Note note)
        {
            context.Notes.Add(note);
            return context.SaveChanges() > 0;
        }

        public bool Update(Note note)
        {
            Note updatedNote = context.Notes.Find(note.ID);
            updatedNote.Title = note.Title;
            updatedNote.Content = note.Content;
            return context.SaveChanges() > 0;
        }

        public bool Delete(Note note)
        {
            Note deletedNote = context.Notes.Find(note.ID);
            deletedNote.IsActive = false;
            return context.SaveChanges() > 0;
        }

    }
}
