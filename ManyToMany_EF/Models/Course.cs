using System.ComponentModel.DataAnnotations;

namespace ManyToMany_EF.Models
{
    public class Course
    {
        public Course() 
        {
            Students = new List<Student>(); //intialize list of students, this can be initialize automatically also.
        }

        public int CourseId { get; set; } //prinary key and identity key

        [Required]
        public string Title { get; set; }

        //Skip navigation properly
        //many to many
        public List<Student> Students {get; set;} //using list collection of students to create relationship students model
    }
}
