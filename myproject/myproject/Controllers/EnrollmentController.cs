using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myproject.Data;
using myproject.Models;

namespace myproject.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Enrollment
        public IActionResult Index()
        {
            var enrollments = _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToList();

            return View(enrollments);
        }

        // GET: /Enrollment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Enrollment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Enrollment enrollment)
        {
            if (enrollment.StudentId > 0 && _context.Students.Find(enrollment.StudentId) == null)
            {
                ModelState.AddModelError(nameof(Enrollment.StudentId),
                    $"No student found with ID {enrollment.StudentId}.");
            }

            if (enrollment.CourseId > 0 && _context.Courses.Find(enrollment.CourseId) == null)
            {
                ModelState.AddModelError(nameof(Enrollment.CourseId),
                    $"No course found with ID {enrollment.CourseId}.");
            }

            if (_context.Enrollments.Any(e => e.StudentId == enrollment.StudentId && e.CourseId == enrollment.CourseId))
            {
                ModelState.AddModelError(string.Empty, "This student is already enrolled in this course.");
            }

            if (!ModelState.IsValid)
            {
                return View(enrollment);
            }

            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}