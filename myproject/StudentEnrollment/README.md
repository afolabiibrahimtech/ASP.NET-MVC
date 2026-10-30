# Student Enrollment

A Student and Course Registration System built with ASP.NET Core MVC. It lets you manage students and courses, and enroll existing students into existing courses.

## Features

### Students
- Create, view, edit, and delete students
- Fields: Name, Program, Email, Phone
- Client-side validation with JavaScript (instant feedback before submitting)
- Server-side validation with Data Annotations, so invalid data cannot be saved even if JavaScript is bypassed
- Edit updates only the permitted fields on the existing database record

### Courses
- Create, view, edit, and delete courses
- Fields: Course Code, Course Name, Instructor, Credit Hours
- Course list enhanced with DataTables: search, column sorting, pagination, and page-size selection
- Delete uses a GET confirmation page and a POST action protected by anti-forgery validation

### Enrollments
- Enroll an existing student in an existing course by entering their IDs
- The server confirms the student and course exist before saving
- Prevents the same student from being enrolled in the same course twice (also enforced by a unique database index)
- Enrollment list with DataTables search, sorting, and pagination

## Tech Stack

- ASP.NET Core MVC (C#)
- Entity Framework Core with SQLite
- Razor views with Tag Helpers
- Bootstrap 5.3.3
- jQuery 3.7.1, jQuery Validation, and jQuery Validation Unobtrusive
- DataTables 1.13.8 (Bootstrap 5 integration)

## Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download)
- Entity Framework Core CLI tools:
  ```bash
  dotnet tool install --global dotnet-ef
  ```

### Run locally
```bash
git clone https://github.com/afolabiibrahimtech/student-enrollment.git
cd student-enrollment
dotnet ef database update
dotnet run
```

Then open the URL shown in the terminal (for example `http://localhost:5123`).

## Project Structure

```
Controllers/
    StudentController.cs      Student CRUD with server-side validation
    CourseController.cs       Course CRUD with POST-only delete
    EnrollmentController.cs   Enroll students in courses by ID
Data/
    ApplicationDbContext.cs   EF Core database context
Models/
    Student.cs                Student model and validation rules
    Course.cs                 Course model and validation rules
    Enrollment.cs             Links a Student to a Course
Views/
    Student/                  Index, Create, Edit, Delete
    Course/                   Index, Create, Edit, Delete
    Enrollment/               Index, Create
    Shared/                   Layout and validation scripts partial
Migrations/                   EF Core database migrations
```

## Validation Rules

| Field | Rule |
|---|---|
| Name | Letters, spaces, hyphens, and apostrophes only |
| Program | Must contain at least one letter; letters, digits, spaces, `& ( ) ' -` allowed |
| Email | Must be a valid email address |
| Phone | 10 to 15 digits; spaces, hyphens, dots, parentheses, and a leading `+` allowed |
| Student ID / Course ID | Must be 1 or higher and must match an existing record |

## Project History

This project was originally created as `myproject` during coursework in a shared repository. It was moved to its own repository with its commit history preserved, and renamed to `StudentEnrollment`.

## Author

Ibrahim Afolabi
[GitHub](https://github.com/afolabiibrahimtech) · [Portfolio](https://mydev-portfolio.org)
