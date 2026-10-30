using System.ComponentModel.DataAnnotations;

namespace StudentEnrollment.ViewModels
{
    public class StudentCreateViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Program { get; set; } = string.Empty;

        [Required]
        public string CourseCode { get; set; } = string.Empty;

        [Required]
        public string CourseName { get; set; } = string.Empty;

        [Required]
        public string Instructor { get; set; } = string.Empty;

        [Required]
        public string EnrollmentDate { get; set; } = string.Empty;
    }
}