using learningactivity1.Models;

namespace learningactivity1.Data
{
    // Simple in-memory storage. Data lasts while the app is running
    // and resets to the starting list when the app restarts.
    public static class CourseRepository
    {
        private static readonly List<Course> _courses = new List<Course>
        {
            new Course { Id = 1, CourseCode = "WEBD1000", CourseName = "Web Design and Development",
                Description = "HTML, CSS, and JavaScript fundamentals for building websites." },
            new Course { Id = 2, CourseCode = "MATH1000", CourseName = "Mathematics for Software Development",
                Description = "Discrete math, logic, and problem-solving for programmers." },
            new Course { Id = 3, CourseCode = "SODV1000", CourseName = "Software Development Techniques",
                Description = "Data structures and algorithms." },
            new Course { Id = 4, CourseCode = "SODV2000", CourseName = "Object-Oriented Programming",
                Description = "Object-oriented programming concepts and software development using C#." },
            new Course { Id = 5, CourseCode = "WEBD2000", CourseName = "Web Programming Foundations",
                Description = "Building web applications using the MVC pattern in ASP.NET Core." }
        };

        private static int _nextId = 6;

        public static List<Course> GetAll()
        {
            return _courses;
        }

        public static Course? GetById(int id)
        {
            return _courses.FirstOrDefault(c => c.Id == id);
        }

        public static void Add(Course course)
        {
            course.Id = _nextId++;
            _courses.Add(course);
        }

        public static bool Update(Course updated)
        {
            var existing = GetById(updated.Id);
            if (existing == null)
            {
                return false;
            }

            existing.CourseCode = updated.CourseCode;
            existing.CourseName = updated.CourseName;
            existing.Description = updated.Description;
            return true;
        }

        // Checks whether another course already uses this code.
        // excludeId lets Edit ignore the course being edited itself.
        public static bool CodeExists(string code, int? excludeId = null)
        {
            return _courses.Any(c =>
                c.CourseCode.Equals(code, StringComparison.OrdinalIgnoreCase) &&
                c.Id != excludeId);
        }
    }
}