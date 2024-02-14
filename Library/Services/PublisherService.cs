using Library.Data;
using Library.Models;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly AppDbContext _context;

        public PublisherService(AppDbContext context)
        {
            _context = context;
        }
        public Task<Publisher> GetItemByIdAsync(int id)
        {
            return _context.Publishers.FindAsync(id).AsTask();
        }

        public Task<List<Publisher>> GetAllItemsAsync()
        {
            return _context.Publishers.ToListAsync<Publisher>();
        }

        public async Task<bool> RemoveItemAsync(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);

            if(publisher is not null)
            {
                _context.Publishers.Remove(publisher);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> SaveItemAsync(Publisher publisher)
        {
            _context.Update(publisher);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
