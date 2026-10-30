using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Models;

namespace StudentEnrollment.Data
{
    // ApplicationDbContext represents our connection to the database
    public class ApplicationDbContext : DbContext
    {
        // Constructor receives database configuration from Program.cs
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Represents the Students table
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}