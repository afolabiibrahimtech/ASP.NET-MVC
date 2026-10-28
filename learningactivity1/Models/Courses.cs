using System.ComponentModel.DataAnnotations;

namespace learningactivity1.Models
{
    public class Course
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Course code is required.")]
        [RegularExpression(@"^[A-Za-z]{4}\d{4}$",
            ErrorMessage = "Course code must be 4 letters followed by 4 digits (e.g. SODV1101).")]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course name is required.")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Course name must be between 3 and 100 characters.")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, MinimumLength = 10,
            ErrorMessage = "Description must be between 10 and 500 characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;
    }
}