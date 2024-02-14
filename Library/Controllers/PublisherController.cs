using Library.Models;
using Library.Services.Interfaces;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        public async Task<IActionResult> Index()
        {
            var publishers = await _publisherService.GetAllItemsAsync();

            return View(new PublisherViewModel
            {
                Alert = (string)TempData[nameof(PublisherViewModel)],
                Publishers = publishers.ToArray()
            });
        }

        public async Task<IActionResult> Add() => View("Edit");

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _publisherService.GetItemByIdAsync(id));
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _publisherService.RemoveItemAsync(id);

            if (response)
            {
                Alert("publisher was successfully removed");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Save(Publisher publisher)
        {
            var response = await _publisherService.SaveItemAsync(publisher);

            if (response)
            {
                Alert($"publisher has been successfully saved");
                return RedirectToAction("Index");
            }

            Alert($"publisher has not been saved");
            return RedirectToAction("Index");
        }


        private void Alert(string text) => TempData[nameof(StudentViewModel.Alert)] = text;
    }
}
