using System.Diagnostics;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using studentmvc.Models;

namespace studentmvc.Controllers;
using studentmvc.Models;
public class StudentController : Controller
{
    public IActionResult Index()
    {
        Student std1 = new Student
        {
            Id=1,
            Name="Saron Tea",
            Age=20,
        };
        
        return View(std1);
    }
    public IActionResult Details()
    {
        return View();
    }
}

//GET, POST PUT and DELETE
//int, string, object etc 