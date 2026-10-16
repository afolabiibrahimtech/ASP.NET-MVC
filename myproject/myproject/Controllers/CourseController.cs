using Microsoft.AspNetCore.Mvc;
using myproject.Data;
using myproject.Models;

namespace myproject.Controllers
{
    public class CourseController : Controller
    {
        // Store the database context in a private variable
        private readonly ApplicationDbContext _context;

        // ASP.NET Core provides ApplicationDbContext
        // through Dependency Injection
        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Course/Index
        public IActionResult Index()
        {
            // Get all courses from the database
            var courses = _context.Courses.ToList();

            // Send the courses to Index.cshtml
            return View(courses);
        }
        // GET: /Course/Create
        public IActionResult Create()
        {
            // Display the empty Create form
            return View();
        }

        // POST: /Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            // Check whether the submitted data is valid
            if (ModelState.IsValid)
            {
                // Add the student to the Students table
                _context.Courses.Add(course);

                // Save the changes to the database
                _context.SaveChanges();

                // Return to the student list
                return RedirectToAction(nameof(Index));
            }

            // If validation fails, display the form again
            return View(course);
        }
        // GET: /Course/Edit/1
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _context.Courses.Find(id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
        // POST: /Courses/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Courses.Update(course);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(course);
        }
        // GET: /Course/Delete/5
        public IActionResult Delete(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: /Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _context.Courses.Find(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}