using Library.Data;
using Library.Models;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }
        public Task<List<Book>> GetAllItemsAsync()
        {
           return _context.Books.ToListAsync();
        }

        public Task<Book> GetItemByIdAsync(int id)
        {
           return _context.Books.FindAsync(id).AsTask();
        }

        public async Task<bool> RemoveItemAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book is not null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> SaveItemAsync(Book item)
        {
            _context.Update(item);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> BorrowAsync(BorrowingRecord record)
        {
            _context.Update(record);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
