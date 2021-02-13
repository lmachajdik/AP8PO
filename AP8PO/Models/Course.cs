using System.Collections.Generic;

namespace AP8PO
{
    internal class Course
    {
        public string Name { get; set; }
        public string Abbrevation { get; set; }
        public int WeekHours { get; set; }
        public SemesterTaught Semester { get; set; }
        public CourseCompletionTypes CompletionType { get; set; }
        public List<CourseCommit> Commits { get; set; }
    }

}
