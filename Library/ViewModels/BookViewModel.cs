using Library.Models;

namespace Library.ViewModels
{
    public record BookViewModel : CommonViewModel
    {
        public Book[] Books { get; set; } = Array.Empty<Book>();
    }
}
