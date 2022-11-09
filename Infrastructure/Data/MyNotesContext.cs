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
        
        public DbSet<Comment> Comments { get; set; }

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

            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<Comment>().HasKey(x => x.Id);
            modelBuilder.Entity<Comment>()
                .Property(x => x.AuthorName)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Comment>()
                .Property(x => x.Content)
                .HasMaxLength(2000);

            modelBuilder
                .Entity<Note>()
                .HasMany(note =>
                    note.Comments)
                .WithOne();
        }
    }
}
