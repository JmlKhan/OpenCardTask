using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasOne(a => a.Book)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(ba => ba.BookID);

            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(ba => ba.AuthorID);

            DataGenerator.InitBogusData();

            modelBuilder.Entity<Student>().HasData(DataGenerator.Students);
            modelBuilder.Entity<Publisher>().HasData(DataGenerator.Publishers);
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<BorrowingRecord> BorrowingRecords { get; set; }

        public DbSet<Book_Author> Book_Authors { get; set; }
    }
}
