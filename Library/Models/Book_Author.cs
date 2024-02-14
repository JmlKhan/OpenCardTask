using Library.Models;

namespace Library.Models
{
    public class Book_Author
    {
        public int Id { get; set; }

        public int BookID { get; set; }
        public Book Book { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }
}
