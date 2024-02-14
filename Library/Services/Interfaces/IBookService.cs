using Library.Models;

namespace Library.Services.Interfaces
{
    public interface IBookService : ICommonServices<Book>
    {
        public Task<bool> BorrowAsync(BorrowingRecord record);
    }
}
