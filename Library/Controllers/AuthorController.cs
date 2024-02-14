using Library.Models;
using Library.Services.Interfaces;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task<IActionResult> Index()
        {
            var authors = await _authorService.GetAllItemsAsync();

            return View(new AuthorViewModel
            {
                Alert = (string)TempData[nameof(AuthorViewModel)],
                Authors = authors.ToArray(),
            });
        }

        public async Task<IActionResult> Add() => View("Edit");

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _authorService.GetItemByIdAsync(id));
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _authorService.RemoveItemAsync(id);

            if (response)
            {
                Alert("Author was successfully removed");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Save(Author publisher)
        {
            var response = await _authorService.SaveItemAsync(publisher);

            if (response)
            {
                Alert($"Author has been successfully saved");
                return RedirectToAction("Index");
            }

            Alert($"Author has not been saved");
            return RedirectToAction("Index");
        }


        private void Alert(string text) => TempData[nameof(AuthorViewModel.Alert)] = text;
    }
}
