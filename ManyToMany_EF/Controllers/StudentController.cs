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

    }
}
