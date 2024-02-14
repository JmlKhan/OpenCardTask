using Bogus;
using Library.Models;

namespace Library.Data
{
    public class DataGenerator
    {
        public static readonly List<Student> Students = new();
        public static readonly List<Publisher> Publishers = new();
        public static readonly List<Author> Authors = new();
        public static readonly List<Book> Books = new();

        public static void InitBogusData()
        {
            GetStudentsData();
            GetPublishersData();
            GetBooksData();
            GetAuthorData();
        }

        private static Faker<Student> GetStudentGenerator()
        {
            var ids = 1;
            return new Faker<Student>()
            .RuleFor(s => s.StudentID, f => f.Random.Int(100) + ids++)
            .RuleFor(s => s.Name, f => f.Name.FirstName())
            .RuleFor(s => s.Email, (f, s) => f.Internet.Email(s.Name))
            .RuleFor(s => s.Address, f => f.Address.FullAddress());
        }

        private static void GetStudentsData()
        {
            var studentsGenerator = GetStudentGenerator();
            var generatedStudents = studentsGenerator.Generate(10);

            Students.AddRange(generatedStudents);
        }

        private static Faker<Publisher> GetPublisherGenerator() 
        {
            var ids = 1;
            return new Faker<Publisher>()
                .RuleFor(p => p.PublisherID, f => f.Random.Int(100) + ids++)
                .RuleFor(p => p.Name, f => f.Name.FindName())
                .RuleFor(p => p.Address, f => f.Address.FullAddress())
                .RuleFor(p => p.ContactInfo, f => f.Lorem.Word());
        }

        private static void GetPublishersData()
        {
            var publisherGenerator = GetPublisherGenerator();
            var generatedPublishers = publisherGenerator.Generate(5);

            Publishers.AddRange(generatedPublishers);
        }

        private static void GetBooksData()
        {
            var generatedBooks = GetGeneratedBooks();

            Books.AddRange(generatedBooks);
        }

        private static void GetAuthorData()
        {
            var authorGenerator = GetAuthorGenerator();
            var generatedAuthors = authorGenerator.Generate(10);
            Authors.AddRange(generatedAuthors);
        }

        private static Faker<Author> GetAuthorGenerator()
        {
            var ids = 1;
            return new Faker<Author>()
                .RuleFor(p => p.AuthorID, f => f.Random.Int(100) + ids++)
                .RuleFor(p => p.Name, f => f.Name.FindName())
                .RuleFor(p => p.Biography, f => f.Lorem.Word());
        }


        private static List<Book> GetGeneratedBooks()
        {
            var ids = 1;
            return new Faker<Book>()
                .RuleFor(p => p.BookID, f => f.Random.Int(100) + ids++)
                .RuleFor(p => p.ISBN, f => f.Random.Int(1000000).ToString())
                .RuleFor(p => p.Genre, f => f.Lorem.Word())
                .RuleFor(p => p.Title, f => f.Lorem.Word())
                .Generate(20);
        }
    }
}
