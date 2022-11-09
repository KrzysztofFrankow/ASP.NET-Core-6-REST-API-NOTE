using Domain.Entities;

namespace Domain.Interfaces
{
    public interface INoteRepository
    {
        IQueryable<Note> GetAll();
        Note GetById(int id);
        Note Add(Note note);
        void Update(Note note);
        void Delete(Note note);
        
        Task<Note> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        Task UpdateAsync(
            Note note,
            CancellationToken cancellationToken = default);
    }
}
