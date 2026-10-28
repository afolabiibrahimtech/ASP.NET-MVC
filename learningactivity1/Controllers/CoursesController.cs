using Microsoft.AspNetCore.Mvc;
using learningactivity1.Data;
using learningactivity1.Models;

namespace learningactivity1.Controllers;

public class CoursesController : Controller
{
    // GET: /Courses
    public IActionResult Index()
    {
        var courses = CourseRepository.GetAll();
        return View(courses);
    }

    // GET: /Courses/Create
    [HttpGet]
    public IActionResult Create()
    {
        return View(new Course());
    }

    // POST: /Courses/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Course course)
    {
        course.CourseCode = course.CourseCode?.Trim().ToUpper() ?? string.Empty;

        // Server-side rule that Data Annotations can't express: no duplicate codes.
        if (CourseRepository.CodeExists(course.CourseCode))
        {
            ModelState.AddModelError(nameof(Course.CourseCode), "A course with this code already exists.");
        }

        if (!ModelState.IsValid)
        {
            // Send the user back to the form with their input and the error messages.
            return View(course);
        }

        CourseRepository.Add(course);
        TempData["Message"] = $"{course.CourseCode} was added successfully.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Courses/Edit/5
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var course = CourseRepository.GetById(id);
        if (course == null)
        {
            return NotFound();
        }

        return View(course);
    }

    // POST: /Courses/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Course course)
    {
        if (id != course.Id)
        {
            return BadRequest();
        }

        if (CourseRepository.GetById(id) == null)
        {
            return NotFound();
        }

        course.CourseCode = course.CourseCode?.Trim().ToUpper() ?? string.Empty;

        if (CourseRepository.CodeExists(course.CourseCode, excludeId: id))
        {
            ModelState.AddModelError(nameof(Course.CourseCode), "Another course already uses this code.");
        }

        if (!ModelState.IsValid)
        {
            return View(course);
        }

        CourseRepository.Update(course);
        TempData["Message"] = $"{course.CourseCode} was updated successfully.";
        return RedirectToAction(nameof(Index));
    }
}