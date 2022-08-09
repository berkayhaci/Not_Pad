using NoteNTier.DAL.Repositories;
using NoteNTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.BLL.Services
{
    public class NoteService
    {
        NoteRepository noteRepository;
        public NoteService()
        {
            noteRepository = new NoteRepository();
        }

        public List<Note> GetById(int userID)
        {
            List<Note> notes = new List<Note>();

            if(userID > 0)
            {
                notes = noteRepository.GetByUserId(userID);
            }
            else
            {
                throw new Exception("Parametre değeri uygun değil");
            }

            return notes;
        }

        public Note GetByNoteId(int noteID)
        {
            Note note = new Note();
            CheckNoteId(noteID);
            note = noteRepository.GetByNoteId(noteID);
            return note;
        }

        void CheckNoteId(int noteID)
        {
            if (noteID <= 0) throw new Exception("Parametre değeri uygun değil");
        }

        public bool Insert(Note note)
        {
            CheckTitleContent(note);
            note.CreationDate = DateTime.Now;
            note.IsActive = true;
            return noteRepository.Insert(note);
        }

        void CheckTitleContent(Note note)
        {
            if (string.IsNullOrWhiteSpace(note.Content) || string.IsNullOrWhiteSpace(note.Title)) throw new Exception("Title ve/veya Content bilgisi eksik");
        }

        public bool Update(Note note)
        {
            CheckTitleContent(note);
            CheckNoteId(note.ID);
            return noteRepository.Update(note);
        }

        public bool Delete(int id)
        {
            CheckNoteId(id);
            Note note = GetByNoteId(id);
            return noteRepository.Delete(note);
        }

        public bool Delete(Note note)
        {
            CheckNoteId(note.ID);
            return noteRepository.Delete(note);
        }
    }
}
