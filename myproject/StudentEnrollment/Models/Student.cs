using System.ComponentModel.DataAnnotations;

namespace StudentEnrollment.Models
{
    public class Student
    {
        public int Id { get; set; }

        // Letters, spaces, hyphens, and apostrophes only.
        [Required(ErrorMessage = "Please enter the student's name.")]
        [RegularExpression(@"^[a-zA-Z\s'-]+$",
            ErrorMessage = "Name must contain only letters, spaces, hyphens, or apostrophes.")]
        public string Name { get; set; } = string.Empty;

        // Letters, digits, spaces, & ( ) ' - only, and at least one letter.
        [Required(ErrorMessage = "Please enter the student's program.")]
        [RegularExpression(@"^(?=.*[a-zA-Z])[a-zA-Z0-9\s&()'-]+$",
            ErrorMessage = "Program must contain at least one letter and no invalid characters.")]
        public string Program { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the student's email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        // 10 to 15 digits; spaces, hyphens, dots, parentheses, and a leading + allowed.
        [Required(ErrorMessage = "Please enter the student's phone number.")]
        [RegularExpression(@"^\+?(?:[\s().-]*\d){10,15}[\s().-]*$",
            ErrorMessage = "Phone number must contain 10 to 15 digits.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; } = string.Empty;
    }
}