using Library.Models;

namespace Library.ViewModels
{
    public record AuthorViewModel : CommonViewModel 
    {
        public Author[] Authors { get; set; } = Array.Empty<Author>();
    }
}
