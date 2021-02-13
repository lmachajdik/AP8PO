using System.Collections.Generic;

namespace AP8PO
{
    internal class StudyProgramme
    {
        public string Name { get; set; }
        public string Abbrevation { get; set; }
        public int StudentsCount { get; set; }
        public int NumberOfWeeks { get; set; }
        public List<Course> Courses { get; set; }
    }
}
