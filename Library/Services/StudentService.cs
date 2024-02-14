using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;

namespace Library.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public Task<Student> GetItemByIdAsync(int id)
        {
            return _context.Students.FindAsync(id).AsTask();
        }

        public Task<List<Student>> GetAllItemsAsync()
        {
            return _context.Students.ToListAsync<Student>();
        }

        public async Task<bool> RemoveItemAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student is not null)
            {
                _context.Remove(student);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> SaveItemAsync(Student student)
        {

            _context.Update(student);

            return await _context.SaveChangesAsync() > 0;
         }
    }
}
