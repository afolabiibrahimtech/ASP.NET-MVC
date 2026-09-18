using Microsoft.AspNetCore.Mvc;
using learningactivity1.Models;

namespace learningactivity1.Controllers;

public class CoursesController : Controller
{
    public IActionResult Index()
    {
        List<Courses> courseList = new List<Courses>
        {
            new Courses { Title = "Web Design and Development", Description = "HTML, CSS, and JavaScript fundamentals for building websites" },
            new Courses { Title = "Mathematics For Software Development", Description = "Discrete math, logic, and problem-solving for programmers" },
            new Courses { Title = "Software Development Techniques", Description = "Data Structures And ALgorithm" },
            new Courses { Title = "Software Development and Object-Oriented", Description = "Object-oriented programming concepts and software development using C#" },
            new Courses { Title = "Web Programming Foundations", Description = "Building web applications using the Model-View-Controller (MVC) pattern in ASP.NET Core" }
        };

        return View(courseList);
    }
}