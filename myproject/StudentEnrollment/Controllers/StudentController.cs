using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Data;
using StudentEnrollment.Models;

namespace StudentEnrollment.Controllers
{
    public class StudentController : Controller
    {
        // Store the database context in a private variable
        private readonly ApplicationDbContext _context;

        // ASP.NET Core provides ApplicationDbContext
        // through Dependency Injection
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        private bool IsDemoUserLoggedIn()
        {
            return !string.IsNullOrEmpty(
                HttpContext.Session.GetString("DemoUser"));
        }

        // GET: /Student/Index
        public IActionResult Index()
        {
            if (!IsDemoUserLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            // Get all students from the database
            var students = _context.Students.ToList();

            // Send the students to Index.cshtml
            return View(students);
        }

        // GET: /Student/Create
        public IActionResult Create()
        {
            if (!IsDemoUserLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            // Display the empty Create form
            return View();
        }

        // POST: /Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken] // Verifies the anti-forgery token for this POST request.
        public IActionResult Create(Student student)
        {
            if (!IsDemoUserLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            // ASP.NET Core has already model-bound the submitted values and
            // evaluated the Student model's Data Annotation validation rules.
            if (!ModelState.IsValid)
            {
                // Return the form with validation errors. Do not save invalid data.
                return View(student);
            }

            // Only valid input reaches the database insert.
            _context.Students.Add(student);
            _context.SaveChanges();

            // Redirect after a successful POST to avoid resubmitting on refresh.
            return RedirectToAction(nameof(Index));
        }

        // GET: /Student/Edit/1
        public IActionResult Edit(int? id)
        {
            if (!IsDemoUserLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == null)
            {
                return NotFound();
            }

            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: /Student/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken] // Rejects requests with missing or invalid anti-forgery data.
        public IActionResult Edit(int id, Student student)
        {
            if (!IsDemoUserLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            // Confirm that the route ID matches the ID submitted with the form.
            if (id != student.Id)
            {
                return BadRequest();
            }

            // Check Data Annotation errors before making any database changes.
            if (!ModelState.IsValid)
            {
                // The asp-validation-for elements can display these model errors.
                return View(student);
            }

            // Load the existing record; do not assume the submitted ID is valid.
            var existingStudent = _context.Students.Find(id);

            if (existingStudent == null)
            {
                return NotFound();
            }

            // Update only the fields this form is allowed to change.
            existingStudent.Name = student.Name;
            existingStudent.Program = student.Program;
            existingStudent.Email = student.Email;
            existingStudent.Phone = student.Phone;

            // Save only after validation and record checks pass.
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: /Student/Delete/1
        public IActionResult Delete(int? id)
        {
            if (!IsDemoUserLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == null)
            {
                return NotFound();
            }

            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: /Student/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!IsDemoUserLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}