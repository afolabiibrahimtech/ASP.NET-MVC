using System.Diagnostics;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using studentmvc.Models;

// //--------------Example1 ----------------------------------
// namespace studentmvc.Controllers;
// using studentmvc.Models;
// public class StudentController : Controller
// {
//     public IActionResult Index()
//     {
//         Student std1 = new Student
//         {
//             Id=1,
//             Name="Saron Tea",
//             Age=20,
//         };

//         return View(std1);
//     }
//     public IActionResult Details()
//     {
//         return View();
//     }
// }

//------------------Example 2 -------------------------

namespace studentmvc.Controllers;

using System.Runtime.CompilerServices;
using studentmvc.Models;
using studentmvc.ViewModels;

public class StudentController : Controller
{
     private static List<Student> students = new List<Student>
        {
            new Student {Id = 1, Name = "Dawit Tesa", Age= 20},
            new Student {Id = 2, Name = "Kaleb Sam" , Age= 19},
            new Student {Id = 2, Name = "Kaleb Sam" , Age= 19},
            new Student {Id = 2, Name = "Kaleb Sam" , Age= 19},
        };

         private static List<Course> courses = new List<Course>
        {
             new Course {Id=1, Name="Maths", Credit=3, Description="Very good course"},
             new Course {Id=23, Name= "Web programming " , Credit = 4, Description="A lot of coding"}
        };

    // public IActionResult Index()
    // {               
    //     return View(students);
    // }
    public IActionResult Index()
    {
        var ViewModel = new StudentCourseViewModel
        {
            students = students,
            courses= courses
        };
        return View (ViewModel);
    }

}

