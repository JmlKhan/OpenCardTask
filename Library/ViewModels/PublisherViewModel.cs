using Library.Models;

namespace Library.ViewModels
{
    public record PublisherViewModel : CommonViewModel
    {
        public Publisher[] Publishers { get; set; } = Array.Empty<Publisher>();
    }
}
