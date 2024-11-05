using ManyToMany_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany_EF.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options):base(options) 
        {

        }

        //These proeprties create our DB tables
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seeding data samples for the database tables
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, Name = "John Doe", FinancialAid = "Passed"},
                new Student { StudentId = 2, Name = "Chris Brown", FinancialAid = "Passed" },
                new Student { StudentId = 3, Name = "Anne Reid", FinancialAid = "Passed" },
                new Student { StudentId = 4, Name = "Kyle Thomas", FinancialAid = "Passed" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, Title = "Intro to Physics" },
                new Course { CourseId = 2, Title = "Web Development I" },
                new Course { CourseId = 3, Title = "Writing I" },
                new Course { CourseId = 4, Title = "History" }
            );

            modelBuilder.Entity<Student>().HasMany(s => s.Courses).WithMany(c => c.Students).UsingEntity(sc => sc.HasData(
               new {CoursesCourseId = 1, StudentsStudentId = 1},
               new { CoursesCourseId = 1, StudentsStudentId = 2 },
               new { CoursesCourseId = 1, StudentsStudentId = 3 },
               new { CoursesCourseId = 1, StudentsStudentId = 4 },
               new { CoursesCourseId = 2, StudentsStudentId = 1 },
               new { CoursesCourseId = 2, StudentsStudentId = 2 },
               new { CoursesCourseId = 2, StudentsStudentId = 3 }
            ));
        }
    }
}
