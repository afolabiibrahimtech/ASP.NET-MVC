using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using learningactivity1.Models;

namespace learningactivity1.Controllers;

public class AboutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}