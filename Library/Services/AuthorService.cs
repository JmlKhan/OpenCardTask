using Library.Data;
using Library.Models;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            _context = context;
        }
        public Task<List<Author>> GetAllItemsAsync()
        {
            return _context.Authors.ToListAsync<Author>();
        }

        public Task<Author> GetItemByIdAsync(int id)
        {
            return _context.Authors.FindAsync(id).AsTask();
        }

        public async Task<bool> RemoveItemAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author is not null)
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> SaveItemAsync(Author item)
        {
            _context.Update(item);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
