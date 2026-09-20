using studentmvc.Models;
namespace studentmvc.ViewModels
{
    public class StudentCourseViewModel
    {
        public List<Student> students {get; set;}
        public List<Course> courses {get;set;}
    }
}