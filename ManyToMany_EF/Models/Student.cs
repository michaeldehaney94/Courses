namespace ManyToMany_EF.Models
{
    public class Student
    {
        public Student()
        {
            Courses = new List<Course>(); //Initialize the list
        }
        public int StudentId { get; set; }

        public string Name { get; set; }

        public string FinancialAid { get; set; }

        //skip navigation property
        //many to many
        public List<Course> Courses { get; set; } //create list collection of courses that will create relationship with courses model

    }
}
