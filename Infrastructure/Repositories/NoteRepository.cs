using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

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
            return _context.Notes;
        }

        public Note GetById(int id)
        {
            return _context.Notes.SingleOrDefault(x => x.Id == id);
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
    }
}
