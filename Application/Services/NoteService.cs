using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;
        public NoteService(INoteRepository noteRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }
        public IEnumerable<NoteDto> GetAllNotes()
        {
            var notes = _noteRepository.GetAll();
            return _mapper.Map<IEnumerable<NoteDto>>(notes);
        }

        public NoteDto GetNoteById(int id)
        {
            var note = _noteRepository.GetById(id);
            return _mapper.Map<NoteDto>(note);
        }

        public NoteDto AddNewNote(CreateNoteDto newNote)
        {
            if(string.IsNullOrEmpty(newNote.Title))
            {
                throw new Exception("Note can not have an empty title");
            }
            var note = _mapper.Map<Note>(newNote);
            _noteRepository.Add(note);
            return _mapper.Map<NoteDto>(note);
        }

        public void UpdateNote(int id, UpdateNoteDto note)
        {
            if (string.IsNullOrEmpty(note.Title))
            {
                throw new Exception("Note can not have an empty title");
            }
            var existingNote = _noteRepository.GetById(id);
            var updatedNote = _mapper.Map(note, existingNote);

            _noteRepository.Update(updatedNote);
        }

        public void DeleteNote(int id)
        {
            var note = _noteRepository.GetById(id);
            _noteRepository.Delete(note);
        } 
    }
}
