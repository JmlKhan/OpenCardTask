using Library.Models;
using Library.Services;
using Library.Services.Interfaces;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Policy;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IPublisherService _publisherService;
        private readonly IAuthorService _authorService;
        private readonly IStudentService _studentService;

        public BookController(IBookService bookService, IPublisherService publisherService, IAuthorService authorService, IStudentService studentService)
        {
            _bookService = bookService;
            _publisherService = publisherService;
            _authorService = authorService;
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllItemsAsync();
         
            return View(new BookViewModel
            {
                Alert = (string)TempData[nameof(BookViewModel)],
                Books = books.ToArray(),
            });
        }

        public async Task<IActionResult> Add() 
        {
            var publishers = await _publisherService.GetAllItemsAsync();

            ViewBag.PublisherId = new SelectList(publishers, "PublisherID", "Name");

            return View("Edit");
        } 

        public async Task<IActionResult> Edit(int id)
        {
            
            return View(await _bookService.GetItemByIdAsync(id));
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _bookService.RemoveItemAsync(id);

            if (response)
            {
                Alert("book was successfully removed");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Borrow(int id) 
        {
            var students = await _studentService.GetAllItemsAsync();
            ViewBag.Students = new SelectList(students, "StudentID", "Name");

            var books = await _bookService.GetAllItemsAsync();
            ViewBag.Books = new SelectList(books, "BookID", "Title");
            return View("Borrow");
        }

        [HttpPost]
        public async Task<ActionResult> SaveBorrowing(BorrowingRecord record)
        {
            record.BorrowingDate = DateTime.UtcNow;
            var response = await _bookService.BorrowAsync(record);

            if(response)
            {
                Alert($"book has been borrowed successfully");
                return RedirectToAction("Index");
            }

            Alert($"book has not been borrowed");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Save(Book book)
        {
          
            var response = await _bookService.SaveItemAsync(book);

            if (response)
            {
                Alert($"book has been successfully saved");
                return RedirectToAction("Index");
            }

            Alert($"book has not been saved");
            return RedirectToAction("Index");
        }

        private void Alert(string text) => TempData[nameof(BookViewModel.Alert)] = text;
    }
}
