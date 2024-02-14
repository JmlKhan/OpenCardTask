using Library.Data;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Remove(int id)
        {
            var record = await _context.BorrowingRecords.FindAsync(id);

            if (record is not null)
            {
                _context.BorrowingRecords.Remove(record);
                await _context.SaveChangesAsync();

                Alert("publisher was successfully removed");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index()
        {
            var borrowings = await _context.BorrowingRecords.ToArrayAsync();


            return View(new BorrowingBooksViewModel()
            {
                Alert = (string)TempData[nameof(BorrowingBooksViewModel)],
                BorrowingBooks = borrowings
            });
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void Alert(string text) => TempData[nameof(BorrowingBooksViewModel.Alert)] = text;
    }
}