using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly MyNotesContext _context;
        public NoteRepository(MyNotesContext context)
        {
            _context = context;
        }
        public IQueryable<Note> GetAll()
        {
            return _context.Notes.Include(note => note.Comments);
        }

        public Note GetById(int id)
        {
            return _context.Notes.Include(note => note.Comments).SingleOrDefault(x => x.Id == id);
        }

        public Note Add(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
            return note;
        }

        public void Update(Note note)
        {
            _context.Notes.Update(note);
            _context.SaveChanges();
        }

        public void Delete(Note note)
        {
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }

        public async Task<Note> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default) =>
                await _context
                    .Notes
                    .FirstAsync(
                        note => note.Id == id,
                        cancellationToken);

        public async Task UpdateAsync(
            Note note,
            CancellationToken cancellationToken = default)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
