using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;

        public DbInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void Run()
        {
            _context.Database.MigrateAsync();
        }


    }
}
