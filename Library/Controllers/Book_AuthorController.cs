using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class Book_AuthorController : Controller
    {
        private readonly AppDbContext _context;

        public Book_AuthorController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var authorBooks = _context.Book_Authors
            .Include(ab => ab.Author)
            .Include(ab => ab.Book)
            .ToList();
            return View(authorBooks);
        }

        public async Task<IActionResult> Add() 
        {
            ViewBag.Books = _context.Books;
            ViewBag.Authors = _context.Authors;

            return View("Create");
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult WriteBook(int authorId, int bookId)
        {
            if (!_context.Authors.Any(a => a.AuthorID == authorId) || !_context.Books.Any(b => b.BookID == bookId))
            {
                return NotFound();
            }

            var existingAssignment = _context.Book_Authors
                .FirstOrDefault(ab => ab.AuthorID == authorId && ab.BookID == bookId);

            if (existingAssignment != null)
            {
                return RedirectToAction(nameof(Index));
            }
            

            var authorBook = new Book_Author { AuthorID = authorId, BookID = bookId };
            _context.Book_Authors.Add(authorBook);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
