using Library.Models;
using Library.Services.Interfaces;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllItemsAsync();

            return View(new StudentViewModel
            {
                Alert = (string)TempData[nameof(StudentViewModel)],
                Students = students.ToArray(),
            });
        }

        public async Task<IActionResult> Add() => View("Edit");

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _studentService.GetItemByIdAsync(id));
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _studentService.RemoveItemAsync(id);

            if (response)
            {
                Alert("Student was successfully removed");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Save(Student student)
        {
            var response = await _studentService.SaveItemAsync(student);

            if (response)
            {
                Alert($"student has been successfully saved");
                return RedirectToAction("Index");
            }

            Alert($"student has not been saved");
            return RedirectToAction("Index");
        }

        private void Alert(string text) => TempData[nameof(StudentViewModel.Alert)] = text;
    }
}
