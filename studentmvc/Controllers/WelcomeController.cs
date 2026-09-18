using System.Diagnostics;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using studentmvc.Models;

namespace studentmvc.Controllers;

public class WelcomeController : Controller
{
    // public string Index()
    // {
    //     return "This is my main or default action...";
    // }

     public string Greeting()
    {
        return "Hello again";
    }

    public IActionResult Index()
    {
        return View();
    }

    //GET: /Welcome/Greetingbyname?name=Mary&numtimes=4
     public string Greetingbyname( string name , int numtimes = 1)
    {
        return  HtmlEncoder.Default.Encode( $"Hello,{name} again, you access this page {numtimes}");
    }
}