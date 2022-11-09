using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface INoteService
    {
        IEnumerable<NoteDto> GetAllNotes();
        NoteDto GetNoteById(int id);
        NoteDto AddNewNote(CreateNoteDto newNote);
        void UpdateNote(int id, UpdateNoteDto note);
        void DeleteNote(int id);
    }
}
