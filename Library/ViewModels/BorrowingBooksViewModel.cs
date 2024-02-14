using Library.Models;

namespace Library.ViewModels
{
    public record BorrowingBooksViewModel : CommonViewModel
    {
        public BorrowingRecord[] BorrowingBooks { get; set; } = Array.Empty<BorrowingRecord>();
    }
}
