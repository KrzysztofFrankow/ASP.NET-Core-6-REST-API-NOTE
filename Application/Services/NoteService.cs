using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

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

        public async Task<CommentDto> AddCommentAsync(
            CreateCommentDto createCommentDto,
            CancellationToken cancellationToken = default)
        {
            var note = await _noteRepository.GetByIdAsync(createCommentDto.NoteId, cancellationToken);

            if (note == null)
            {
                throw new Exception("Nie ma!");
            }

            var comment = new Comment
            {
                AuthorName = createCommentDto.AuthorName,
                Content = createCommentDto.Content,
                CreationTimestampUtc = DateTime.UtcNow
            };

            note.Comments.Add(comment);

            await _noteRepository.UpdateAsync(note, cancellationToken);

            var commentDto = _mapper.Map<CommentDto>(comment);

            return commentDto;
        }
    }
}
