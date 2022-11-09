using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    public class MyNotesContext : DbContext
    {
        public MyNotesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().ToTable("Notes");
            modelBuilder.Entity<Note>().HasKey(x => x.Id);
            modelBuilder.Entity<Note>()
                .Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Note>()
                .Property(x => x.Content)
                .HasMaxLength(2000);
        }
    }
}
