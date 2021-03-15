using System.Collections.Generic;

namespace AP8PO
{
    public class Course
    {
        public string Name { get; set; }
        public string Abbrevation { get; set; }
        public int NumberOfWeeks { get; set; }

        public int HoursOfLectures { get; set; }
        public int HoursOfClasses { get; set; }
        public int HoursOfSeminars { get; set; }

        public CourseCompletionTypes CompletionType { get; set; }
        public Language Language { get; set; }
        public int MaxStudents { get; set; }
    }

}
