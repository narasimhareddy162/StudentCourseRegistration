using Microsoft.AspNetCore.Mvc;
using StudentCourseRegistration.Models;

namespace StudentCourseRegistration.Controllers;

public class StudentController : Controller
{
    // "static" means the list stays alive for the whole time the app is running.
    // (A controller is created again for every request, so a normal list would be emptied each time.)
    private static readonly List<Student> _students = new();
    private static int _nextId = 1;

    // Shows the list of all students.  URL: /Student
    public IActionResult Index()
    {
        return View(_students);   // sends the list to Views/Student/Index.cshtml
    }

    // Shows the empty registration form.  URL: /Student/Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // Runs when the form is submitted.
    // MODEL BINDING: ASP.NET Core automatically copies the form values into the "student" object.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Student student)
    {
        if (ModelState.IsValid)   // true only if all validation rules pass
        {
            student.Id = _nextId++;
            _students.Add(student);

            TempData["SuccessMessage"] = "Student registered successfully!";
            return RedirectToAction(nameof(Index));
        }

        // Validation failed: show the same form again with error messages.
        return View(student);
    }

    // Shows one student.  URL: /Student/Details/1
    public IActionResult Details(int id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);

        if (student == null)
        {
            return NotFound();   // shows a 404 page if the id does not exist
        }

        return View(student);
    }
}