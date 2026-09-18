using Microsoft.AspNetCore.Mvc;
using MyMvcTest.Models;

namespace MyMvcTest.Controllers

{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Sarah Ahmed",
                    Program = "Software Development"
                },

                new Student
                {
                    Id = 2,
                    Name = "Michael Chen",
                    Program = "Cybersecurity"
                },

                new Student
                {
                    Id = 3,
                    Name = "David Smith",
                    Program = "Data Analytics"
                }
            };
        // action method
        public IActionResult Index()
        {
            return View(students);
        }
        public string Greet()
        {
            return "Hello class this is greet action";
        }
        public IActionResult Create(Student student)
        {
            students.Add(student);
            return RedirectToAction("Index");

        }
    }
    
}