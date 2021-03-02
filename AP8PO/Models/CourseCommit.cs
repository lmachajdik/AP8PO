﻿using System.Collections.Generic;

namespace AP8PO
{
    public class CourseCommit
    {
        public string Name { get; set; }
        public string Abbrevation { get; set; }
        public int Hours { get; set; }
        public int NumberOfStudents { get; set; }
        public Course Course { get; set; }
        public Employee Employee { get; set; }
        public CourseType CourseType { get; set; }
        public Language Language { get; set; }
    }
}
