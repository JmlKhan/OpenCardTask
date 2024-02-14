namespace Library.Models
{
    public class Book
    {
        public int BookID { get; set; }

        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public List<Book_Author> Book_Authors { get; set; }
    }
}
