using System.ComponentModel.DataAnnotations;

namespace myproject.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid student ID.")]
        [Display(Name = "Student ID")]
        public int StudentId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid course ID.")]
        [Display(Name = "Course ID")]
        public int CourseId { get; set; }

        public Student? Student { get; set; }

        public Course? Course { get; set; }
    }
}