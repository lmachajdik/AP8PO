using System.Collections.Generic;

namespace AP8PO
{
    internal class CourseCommit
    {
        public int Hours { get; set; }
        public List<Teacher> Teacher { get; set; }
        public CourseType CourseType { get; set; }
    }

}
