using AP8PO.Enums;
using System.Collections.Generic;

namespace AP8PO
{
    internal class Group
    {
        public string Name { get; set; }
        public string Abbrevation { get; set; }

        public Semester Semester { get; set; }
        public StudyForm StudyForm { get; set; }
        public StudyType StudyType { get; set; }

        public int StudentsCount { get; set; }
        public int Year { get; set; }

        public List<Course> Courses { get; set; }
    }
}
