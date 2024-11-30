using ManyToMany_EF.Data;
using ManyToMany_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany_EF.Controllers
{

    public class StudentController : Controller
    {
        private readonly Context _db;

        public StudentController(Context db)    
        { 
            _db = db;
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Index()
        {
           ViewBag.Courses =await _db.Courses.ToListAsync();  
            return View(await _db.Students.ToListAsync());
        }


        public async Task<IActionResult> ChangeCourse(int courseId)
        {
            List<Student> studentsInCourse;
            ViewBag.Courses = await _db.Courses.ToListAsync();
            ViewBag.SelectedCourse = courseId;

            if (courseId != 0)
            {
                //checks to see if student has any courses by using the course id to find said course
                studentsInCourse = await _db.Students.Where(s => s.Courses.Any(c => c.CourseId==courseId)).ToListAsync();
            }
            else
            {
                studentsInCourse = await _db.Students.ToListAsync();         
            }

            return View("Index", studentsInCourse);
        }

        [HttpGet]
        public async Task<IActionResult> EnrollNewStudent()
        {
            ViewBag.Courses = await _db.Courses.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnrollNewStudent(Student s, string[] enrolledCourses)
        {

            if (enrolledCourses != null)
            {
                foreach (var courseId in enrolledCourses)
                {
                    Course c = _db.Courses.Find(int.Parse(courseId));
                    s.Courses.Add(c);
                }
            }
            _db.Students.Add(s);
            await _db.SaveChangesAsync();
            List<Student> students = await _db.Students.ToListAsync();
            ViewBag.Courses = await _db.Courses.ToListAsync();
            return View("Index", students);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeEnrollment(int id)
        {
            var student = await _db.Students.Include(s => s.Courses).FirstOrDefaultAsync(s => s.StudentId == id);
            ViewBag.Courses = await _db.Courses.ToListAsync();
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> ModifyStudentEnrolledCourses(Student s, string[] enrolledCourses)
        {
            //Student student = await _db.Students.Include(s => s.Courses).FirstOrDefaultAsync(s => s.StudentId == s.StudentId);
            Student student = await _db.Students.Where(s => s.StudentId == s.StudentId).Include(s => s.Courses).FirstOrDefaultAsync();
            student.Courses.Clear();
            if (enrolledCourses != null)
            {
                foreach (var courseId in enrolledCourses)
                {
                    Course c = _db.Courses.Find(int.Parse(courseId));
                    student.Courses.Add(c);
                }
            }
            await _db.SaveChangesAsync();
            List<Student> students = await _db.Students.ToListAsync();
            ViewBag.Courses = await _db.Courses.ToListAsync();
            return View("Index", students);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteStudent(int id)
        {
           return View(await _db.Students.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudent(Student s)
        {
            Student student = await _db.Students.Where(s => s.StudentId == s.StudentId).Include(s => s.Courses).FirstOrDefaultAsync();

            _db.Students.Remove(s);
            await _db.SaveChangesAsync();
            List<Student> students = await _db.Students.ToListAsync();
            ViewBag.Courses = await _db.Courses.ToListAsync();
            return View("Index", students);
        }

    }
}
