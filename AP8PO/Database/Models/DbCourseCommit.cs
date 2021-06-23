using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP8PO.Database.Models
{
    public class DbCourseCommit
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abbrevation { get; set; }
        public int Hours { get; set; }
        public int NumberOfStudents { get; set; }
        //public Course Course { get; set; }
        //public DbEmployee Employee { get; set; }
        public CourseType CourseType { get; set; }
        public Language Language { get; set; }
    }
}
