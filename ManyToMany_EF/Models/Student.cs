namespace ManyToMany_EF.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string Name { get; set; }

        public string FinancialAid { get; set; }

        //skip navigation property
        //many to many
        public List<Course> Courses { get; set; } //create list collection of courses that will create relationship with courses model

    }
}
