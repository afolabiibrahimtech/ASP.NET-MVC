using System.ComponentModel.DataAnnotations;

namespace myproject.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string CourseCode { get; set; } = string.Empty;

        [Required]
        public string CourseName { get; set; } = string.Empty;

        [Required]
        public string Instructor { get; set; } = string.Empty;

        [Required]
        [Range(1, 6, ErrorMessage = "Credit hours must be between 1 and 6.")]
        [Display(Name = "Credit Hours")]
        public int CreditHours { get; set; }
    }
}