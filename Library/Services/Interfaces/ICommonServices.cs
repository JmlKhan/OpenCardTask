using Library.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Library.Services.Interfaces
{
    public interface ICommonServices<T> where T : class
    {
        public Task<List<T>> GetAllItemsAsync();

        public Task<T> GetItemByIdAsync(int id);

        public Task<bool> SaveItemAsync(T item);

        public Task<bool> RemoveItemAsync(int id);
    }
}
