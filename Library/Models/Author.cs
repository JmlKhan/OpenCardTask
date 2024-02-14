namespace Library.Models
{
    public class Author
    {
        public int AuthorID { get; set; }

        public string Name { get; set; }

        public string Biography { get; set; }

        public List<Book_Author> Book_Authors { get; set; } = default!;
    }
}
