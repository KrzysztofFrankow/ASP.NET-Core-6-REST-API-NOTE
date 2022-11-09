using Application.Dto;

namespace Application.Interfaces
{
    public interface INoteService
    {
        IEnumerable<NoteDto> GetAllNotes();
        NoteDto GetNoteById(int id);
        NoteDto AddNewNote(CreateNoteDto newNote);
        void UpdateNote(int id, UpdateNoteDto note);
        void DeleteNote(int id);

        Task<CommentDto> AddCommentAsync(
            CreateCommentDto createCommentDto,
            CancellationToken cancellationToken = default);
    }
}
